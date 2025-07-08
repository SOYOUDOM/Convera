using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covera.PolicyImagingSystem.Core.Helper
{
    public class PathStatic
    {
        public static string COI = Path.Combine(DateTime.Today.ToString("yyyy-MM-dd"), "COI");
    }
}
