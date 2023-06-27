using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Implementation;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface;
using Com.ACSCorp.AccountPlanning.Service.Common.HttpServices;
using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Repository;
using Com.ACSCorp.AccountPlanning.Service.Repository.ClaimRepository;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Com.ACSCorp.AccountPlanning.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Com.ACSCorp.AccountPlanning.Service.DependencyResolver
{
    public static class DependenciesResolver
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SampleContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddDbContext<AccountPlanningContext>(options => options.UseSqlServer(configuration.GetConnectionString("AccountPlanning")));



            services.InjectServices();
            services.InjectRepositories();
            return services;
        }

        internal static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IClaimRepository,ClaimRepository>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IHttpServiceFactory, HttpServiceFactory>();
            services.AddScoped<IHttpHeaderService, HttpHeaderService>();
            services.AddScoped<ICustomerInfoService, CustomerInfoService>();
            services.AddScoped<IOpportunitiesService, OpportunitiesService>();
            services.AddScoped<IDesignationService, DesignationService>();
            services.AddScoped<IInnovaUserService, InnovaUserService>();
            services.AddScoped<IOrgHierarchyService, OrgHierarchyService>();
            services.AddScoped<IInfluencerService, InfluencerService>();
            services.AddScoped<ICustomerUsersService, CustomerUsersService>();
            services.AddScoped<IEngagementService, EngagementService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IImportExportDMService, ImportExportDMService>();
            services.AddScoped<IOpportunitiesService, OpportunitiesService>();
            services.AddScoped<IUserDetailsService, UserDetailsService>();
            services.AddScoped<IEnablerService, EnablerService>();




            return services;
        }

        internal static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<ICustomerInfoRepository, CustomerInfoRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IInnovaUserRepository, InnovaUserRepository>();
            services.AddScoped<IOrgHierarchyRepository, OrgHierarchyRepository>();
            services.AddScoped<IInfluencerRepository, InfluencerRepository>();
            services.AddScoped<ICustomerUsersRepository, CustomerUsersRepository>();
            services.AddScoped<IEngagementRepository, EngagementRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IImportExportDMRepository, ImportExportDMRepository>();
            services.AddScoped<IOpportunitiesRepository, OpportunitiesRepository>();
            services.AddScoped<IUserDetailsRepository, UserDetailsRepository>();
            services.AddScoped<IEnablerRepository, EnablerRepository>();



            return services;
        }
    }
}