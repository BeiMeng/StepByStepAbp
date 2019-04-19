using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Abp.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using Castle.Facilities.Logging;
using Abp.Castle.Logging.Log4Net;
using Abp.Extensions;
using System.IO;
using System.Reflection;
using Abp.Reflection.Extensions;
using BeiDream.SbsAbp.Zero.Identity;
using BeiDream.SbsAbp.Configuration;
using BeiDream.SbsAbp.Web.Authentication;
using BeiDream.SbsAbp.Web.Middleware.HandNotFound;

namespace BeiDream.SbsAbp.Web.Host
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";

        public IConfiguration Configuration { get; }

        private readonly IConfigurationRoot _appConfiguration;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _appConfiguration = env.GetAppConfiguration();
        }

       
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //身份认证相关注册
            IdentityRegistrar.Register(services);
            //开启jwt 认证
            AuthConfigurer.Configure(services, _appConfiguration);

            // Configure CORS for Client UI
            services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            _appConfiguration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);  //swagger 显示动态生成的appliction层api

                // Set the comments path for the Swagger JSON and UI.显示Swagger文档注释
                var xmlFile = $"{typeof(SbsAbpApplicationModule).GetAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

            });

            //Configure Abp and Dependency Injection
            return services.AddAbp<SbsAbpWebHostModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAbp(); //Initializes ABP framework.

            app.UseCors(_defaultCorsPolicyName); // Enable CORS!

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseHandNotFoundMiddleware();
        }
    }
}
