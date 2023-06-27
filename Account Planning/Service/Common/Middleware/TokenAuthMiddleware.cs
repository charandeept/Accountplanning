using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model;
using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using Com.ACSCorp.AccountPlanning.Service.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Middleware
{
    public class TokenAuthMiddleware
    {
        private readonly RequestDelegate _next;
        

        public TokenAuthMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task InvokeAsync(HttpContext context,IIdentityService identityService, ITokenService tokenService, IClaimService claimService)
        {
            string token = context.Request.Headers[HeaderNames.Authorization];

            if (token != null)
            {
                if (token.Contains("Bearer"))
                {
                    token = token.Remove(0, 7);
                }
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Authentication required");
                return;
            }

            bool isValidToken = tokenService.IsTokenValid(token);
            if (!isValidToken)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Token is invalid or expired"); //TODO: Log this message and send back generic message in response
                return;
            }

            ClaimsModel claims = tokenService.GetUserClaims(token);

            if (claims == null || string.IsNullOrWhiteSpace(claims.email))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("User does not have email claim"); //TODO: Log this message and send back generic message in response
                return;
            }

            var user = claimService.GetUser(claims.email);

            EmployeeRole role = EmployeeRole.Any;
            if (user.IsDeliveryManager)
            {
                role = EmployeeRole.Manager;
            }
            else if (user.IsLeader)
            {
                role = EmployeeRole.Leader;
            }
            else if (user.IsGuestUser)
            {
                role = EmployeeRole.GuestUser;
            }
            //else if (user.IsActive)
            //{
            //    role = EmployeeRole.ac;
            //}

            //TODO: Get the User context from Database. 
            if (user != null)
            {
                // Get the User context from Database.
                identityService.SetUser(new CurrentUser()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    //LastName = user.LastName,
                    IsActive = user.IsActive,
                    IsDeliveryManager = user.IsDeliveryManager,
                    IsGuestUser = user.IsGuestUser,
                    IsLeader = user.IsLeader,
                    Roles = new List<EmployeeRole>() { role }
                });
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("User does not found");
            }

            await _next.Invoke(context);
        }
    }
}
