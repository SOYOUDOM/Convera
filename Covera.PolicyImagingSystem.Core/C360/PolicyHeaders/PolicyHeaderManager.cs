using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Covera.PolicyImagingSystem.Core.C360.LifeAssures;
using Covera.PolicyImagingSystem.Core.C360.PolicyOwners;
using Microsoft.EntityFrameworkCore;

namespace Covera.PolicyImagingSystem.Core.C360.PolicyHeaders
{
    public class PolicyHeaderManager : IMRDomainServiceBase,IPolicyHeaderManager
    {
        private readonly IRepository<PolicyHeader, string> _policyHeaderRepository;
        private readonly IRepository<LifeAssure, string> _lifeAssureRepository;
        private readonly IRepository<PolicyOwner, string> _policyOwnerRepository;
        public PolicyHeaderManager(IRepository<PolicyOwner, string> policyOwnerRepository, IRepository<LifeAssure, string> lifeAssureRepository, IRepository<PolicyHeader, string> policyHeaderRepository)
        {
            _policyOwnerRepository = policyOwnerRepository;
            _lifeAssureRepository = lifeAssureRepository;
            _policyHeaderRepository = policyHeaderRepository;
        }

        public async Task<List<PolicyHeader>> GetPolicyHeadersListAsync(List<string>? policyNumbers = null)
        {
            var result = await _policyHeaderRepository
                .GetAll()
                .AsNoTracking()
                .Where(x => x.ContractStatus == "IF" && policyNumbers!.Contains(x.Id))
                .ToListAsync();
            return result;
        }

        public async Task<List<LifeAssure>> GetLifeAssureAsync(string policyNumber)
        {
            var result = await _lifeAssureRepository
                .GetAll()
                .AsNoTracking()
                .Where(x => x.Id == policyNumber)
                .ToListAsync();
            return result;
        }

        public async Task<PolicyOwner> GetPolicyOwnerAsync(string policyNumber)
        {
            var policyHeader = await _policyHeaderRepository
                .GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == policyNumber);

            var result = await _policyOwnerRepository.GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == policyHeader!.PolicyOwnerNumber);
            return result!;
        }
    }
}
