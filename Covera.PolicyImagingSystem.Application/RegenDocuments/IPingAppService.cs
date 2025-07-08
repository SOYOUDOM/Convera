using System.Threading.Tasks;
using Abp.Application.Services;

namespace Covera.PolicyImagingSystem.Application.RegenDocuments
{
    public interface IPingAppService : IApplicationService
    {
        Task<string> Ping();
    }
}