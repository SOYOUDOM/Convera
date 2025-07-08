using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Covera.PolicyImagingSystem.Core;

namespace Covera.PolicyImagingSystem.Application
{
    public abstract class IMRAppServiceBase: ApplicationService
    {
        protected IMRAppServiceBase()
        {
            LocalizationSourceName = IMRConsts.LocalizationSourceName;
        }
    }
}
