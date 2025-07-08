using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Reflection.Extensions;
using Abp.Zero;
using Abp.Zero.Configuration;

namespace Covera.PolicyImagingSystem.Core
{
    [DependsOn(
        typeof(AbpZeroCoreModule)
    )]
    public class IMRCoreModule : AbpModule
    {
        public override void PreInitialize()
        {

            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IMRCoreModule).GetAssembly());
        }
    }
}
