using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covera.PolicyImagingSystem.Application.DocumentGeneratorManagers;

namespace Covera.PolicyImagingSystem.Application.RegenDocuments
{
    public class RegenDocumentAppService: IMRAppServiceBase, IRegenDocumentAppService
    {
        public readonly IDocumentGeneratorManager _documentGeneratorManager;

        public RegenDocumentAppService(IDocumentGeneratorManager documentGeneratorManager)
        {
            _documentGeneratorManager = documentGeneratorManager;
        }

        public Task<string> ReGenCOI(List<string> policyNumbers)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReGenLetter(List<string> policyNumbers)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReGenPOLCON(List<string> policyNumbers)
        {
            throw new NotImplementedException();
        }
    }
}
