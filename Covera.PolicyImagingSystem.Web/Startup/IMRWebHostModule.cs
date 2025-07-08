using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCompanyName.AbpProjectName.Configuration;
using Covera.PolicyImagingSystem.Application;
using Covera.PolicyImagingSystem.Core;
using Covera.PolicyImagingSystem.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Covera.PolicyImagingSystem.Web.Startup
{
    [DependsOn(
        typeof(AbpAspNetCoreModule), 
        typeof(IMRApplicationModule), 
        typeof(IMREntityFrameworkCoreModule), 
        typeof(IMRCoreModule))]
    public class IMRWebHostModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public IMRWebHostModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(IMRWebHostModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IMRWebHostModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(IMRWebHostModule).Assembly);
        }
    }
}