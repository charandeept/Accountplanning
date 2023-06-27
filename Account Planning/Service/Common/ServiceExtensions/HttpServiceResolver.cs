using Com.ACSCorp.AccountPlanning.Service.Common.HttpServices;

using Microsoft.Extensions.DependencyInjection;

namespace Com.ACSCorp.AccountPlanning.Service.Common.ServiceExtensions
{
    public static class HttpServiceResolver
    {
        public static void AddHttpService(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IHttpServiceFactory, HttpServiceFactory>();
            services.AddScoped<IHttpHeaderService, HttpHeaderService>();
        }
    }
}