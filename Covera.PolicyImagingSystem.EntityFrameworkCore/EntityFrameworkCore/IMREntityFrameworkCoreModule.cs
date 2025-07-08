using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Covera.PolicyImagingSystem.Core;

namespace Covera.PolicyImagingSystem.EntityFrameworkCore.EntityFrameworkCore
{
    [DependsOn(
        typeof(IMRCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class IMREntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IMREntityFrameworkCoreModule).GetAssembly());
        }
    }
}
