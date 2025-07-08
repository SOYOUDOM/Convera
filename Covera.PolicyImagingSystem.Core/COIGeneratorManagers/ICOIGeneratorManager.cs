using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covera.PolicyImagingSystem.Core.COIGeneratorManagers
{
    public interface ICOIGeneratorManager
    {
        /// <summary>
        /// Generates a Certificate of Insurance (COI) based on the provided parameters.
        /// </summary>
        /// <param name="policyNumber">The policy number for which the COI is generated.</param>
        /// <param name="effectiveDate">The effective date of the COI.</param>
        /// <param name="expirationDate">The expiration date of the COI.</param>
        /// <returns>A string representing the generated COI.</returns>
        string GenerateCOI(string policyNumber, DateTime effectiveDate, DateTime expirationDate);
    }
}
