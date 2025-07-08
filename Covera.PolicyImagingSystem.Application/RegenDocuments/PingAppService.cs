using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Covera.PolicyImagingSystem.Application.RegenDocuments
{
[ApiController]
[Route("api/policies")]
    public class PingAppService : IMRAppServiceBase, IPingAppService
    {
        public Task<string> Ping()
        {
            return Task.FromResult("pong");
        }
    }
}