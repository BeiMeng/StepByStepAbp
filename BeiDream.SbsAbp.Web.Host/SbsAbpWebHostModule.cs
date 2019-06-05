﻿using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using BeiDream.SbsAbp.Common;
using BeiDream.SbsAbp.Configuration;
using BeiDream.SbsAbp.EntityFrameworkCore;
using BeiDream.SbsAbp.Web.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Web
{
    [DependsOn(
        typeof(SbsAbpApplicationModule),
        typeof(SbsAbpEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreSignalRModule),
        typeof(AbpHangfireAspNetCoreModule),
         typeof(AbpAspNetCoreModule))]
    public class SbsAbpWebHostModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SbsAbpWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {
            //从appsettings.json获取数据库链接字符串并配置为默认链接
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(SbsAbpConsts.ConnectionStringName);

            // Use database for language management
            //使用数据库的语言管理数据
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //将application层 动态生成 webapi
            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(SbsAbpApplicationModule).GetAssembly()
                );

            ConfigureTokenAuth();

            Configuration.BackgroundJobs.UseHangfire();
        }
        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = AppConsts.AccessTokenExpiration;
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SbsAbpWebHostModule).GetAssembly());
        }
    }
}
