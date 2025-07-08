using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Covera.PolicyImagingSystem.Core;

namespace Covera.PolicyImagingSystem.Application
{
    [DependsOn(
        typeof(IMRCoreModule),
        typeof(AbpAutoMapperModule)
        )]
    public class IMRApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IMRApplicationModule).GetAssembly());
        }
    }
}
