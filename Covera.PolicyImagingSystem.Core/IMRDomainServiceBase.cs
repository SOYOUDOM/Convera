using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Covera.PolicyImagingSystem.Core
{
    public class IMRDomainServiceBase : DomainService
    {
        protected IMRDomainServiceBase()
        {
            LocalizationSourceName = IMRConsts.LocalizationSourceName;
        }
    }
}
