using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;

namespace Covera.PolicyImagingSystem.Core
{
    public class User : AbpUser<User>
    {
    }

    public class Role : AbpRole<User>
    {
        public Role() { }
        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {
        }
    }

    public class Tenant : AbpTenant<User>
    {
        public Tenant() { }
        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
