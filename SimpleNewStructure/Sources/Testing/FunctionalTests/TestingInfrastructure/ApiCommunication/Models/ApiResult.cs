using System.Net.Http;
using System.Threading.Tasks;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Invariance;
using Newtonsoft.Json;

namespace Mmu.CleanDddSimple.FunctionalTests.TestingInfrastructure.ApiCommunication.Models
{
    public class ApiResult
    {
        public ApiResult(HttpResponseMessage response)
        {
            Guard.ObjectNotNull(() => response);
            Response = response;
        }

        public HttpResponseMessage Response { get; }

        public async Task<T> ReadContentAsync<T>()
        {
            var content = await Response.Content.ReadAsStringAsync();

#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
            return JsonConvert.DeserializeObject<T>(content)!;
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
        }
    }
}