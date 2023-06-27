using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Implementation;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface;
using Com.ACSCorp.AccountPlanning.Service.Common.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Common.ServiceExtensions
{
    public static class TokenAuthMiddlewareExtension
    {
        public static IApplicationBuilder UseTokenAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenAuthMiddleware>();
        }
    }

    public static class TokenAuthResolver
    {
        public static void AddAuthService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
