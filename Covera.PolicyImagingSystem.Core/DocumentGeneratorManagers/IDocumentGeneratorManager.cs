using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covera.PolicyImagingSystem.Core.C360.PolicyHeaders;

namespace Covera.PolicyImagingSystem.Application.DocumentGeneratorManagers
{
    public interface IDocumentGeneratorManager
    {
        Task GenerateCOIDocument(List<PolicyHeader> policyHeaders);
    }
}
