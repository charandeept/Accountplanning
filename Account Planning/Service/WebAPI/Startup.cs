using AspNet.Security.OAuth.Validation;
using Com.ACSCorp.AccountPlanning.Service.Common.Middleware;
using Com.ACSCorp.AccountPlanning.Service.Common.ServiceExtensions;
using Com.ACSCorp.AccountPlanning.Service.DependencyResolver;
using Com.ACSCorp.AccountPlanning.Service.Repository.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
namespace Com.ACSCorp.AccountPlanning.Service.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddHttpContextAccessor();
            // services.AddHttpService();
            //services.AddAuthService();
            //services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddAuthentication(OAuthValidationDefaults.AuthenticationScheme)
                    .AddOAuthValidation();
            DependenciesResolver.ResolveDependencies(services, Configuration);
            //services.AddCors(x => x.AddPolicy("xxx", build => build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()));
            services.AddAutoMapper(typeof(ApplicationMapper));
            services.AddCors(p => p.AddPolicy("AccountPlanningFrontEnd", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Account Planning API",
                    Description = "Account Planning API",
                    Contact = new OpenApiContact
                    {
                        Name = "ACS Corp",
                        Email = string.Empty,
                        Url = new Uri("https://www.innovasolutions.com/"),
                    },
                });
                c.AddSecurityDefinition("token", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="token"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AccountPlanning API V1");
                c.RoutePrefix = string.Empty;
            });
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AccountPlanningFrontEnd");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<TokenAuthMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
