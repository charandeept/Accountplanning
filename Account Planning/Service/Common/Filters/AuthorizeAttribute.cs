using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model;
using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Filters
{

    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(params EmployeeRole[] allowedRoles) : base(typeof(AuthorizeRolesActionFilter))
        {
            Arguments = new object[] { allowedRoles };
        }
    }

    public class AuthorizeRolesActionFilter : IAuthorizationFilter
    {
        private EmployeeRole[] AllowedRoles { get; set; }

        public AuthorizeRolesActionFilter(params EmployeeRole[] allowedRoles)
        {
            AllowedRoles = allowedRoles;
        }

        /// <summary>
        /// On Authorization
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            IIdentityService identityService = context.HttpContext.RequestServices.GetService(typeof(IIdentityService)) as IIdentityService;

            CurrentUser currentUser = identityService.GetCurrentUser();
            if (currentUser == null)
            {
                context.Result = new UnauthorizedResult();
            }

            bool userPermitted = IsUserRolePermitted(currentUser);
            if (!userPermitted)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool IsUserRolePermitted(CurrentUser user)
        {
            // If no roles are defined or Authorize for any user then allow access
            if (AllowedRoles == null || AllowedRoles.Length == 0 || AllowedRoles[0] == EmployeeRole.Any)
            {
                return true;
            }

            // If user is not present then restrict the access
            if (user == null)
            {
                return false;
            }


            if (AllowedRoles[0] == user.Roles[0])
            {
                return true;
            }

            // If user is Admin or Manager or Techlead or Architect then allow the access
            //if (user.IsLeader || user.IsDeliveryManager || user.IsGuestUser)
            //{
            //    return true;
            //}

            if (user.Roles == null || user.Roles.Count == 0)
            {
                return false;
            }

            foreach (EmployeeRole allowedRole in AllowedRoles)
            {
                int matchIndex = user.Roles.FindIndex(r => r == allowedRole);
                if (matchIndex > -1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
