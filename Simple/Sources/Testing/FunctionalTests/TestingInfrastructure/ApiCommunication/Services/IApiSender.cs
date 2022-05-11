using System.Net.Http;
using System.Threading.Tasks;
using Mmu.CleanDddSimple.FunctionalTests.TestingInfrastructure.ApiCommunication.Models;

namespace Mmu.CleanDddSimple.FunctionalTests.TestingInfrastructure.ApiCommunication.Services
{
    public interface IApiSender
    {
        Task<ApiResult> SendAsync(
            HttpClient client,
            HttpMethod method,
            string relativeUrl,
            object? bodyObj = null);
    }
}