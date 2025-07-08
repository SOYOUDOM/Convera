using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covera.PolicyImagingSystem.Core.C360.LifeAssures;
using Covera.PolicyImagingSystem.Core.C360.PolicyOwners;

namespace Covera.PolicyImagingSystem.Core.C360.PolicyHeaders
{
    public interface IPolicyHeaderManager
    {
        Task<List<PolicyHeader>> GetPolicyHeadersListAsync(List<string>? policyNumbers = null);
        Task<List<LifeAssure>> GetLifeAssureAsync(string policyNumber);
        Task<PolicyOwner> GetPolicyOwnerAsync(string policyNumber);
    }
}
