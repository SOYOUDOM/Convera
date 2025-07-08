using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covera.PolicyImagingSystem.Application.RegenDocuments
{
    public interface IRegenDocumentAppService : IApplicationService
    {
        Task<string> ReGenCOI(List<string> policyNumbers);
        Task<string> ReGenLetter(List<string> policyNumbers);
        Task<string> ReGenPOLCON(List<string> policyNumbers);

    }
}
