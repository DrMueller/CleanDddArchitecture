using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.FunctionalTests.Infrastructure.ApiCommunication.Models;
using Newtonsoft.Json;

namespace Mmu.CleanDddSimple.FunctionalTests.Infrastructure.ApiCommunication.Services.Implementation
{
    [UsedImplicitly]
    public class ApiSender : IApiSender
    {
        public async Task<ApiResult> SendAsync(
            HttpClient client,
            HttpMethod method,
            string relativeUrl,
            object? bodyObj = null)
        {
            var message = new HttpRequestMessage(method, relativeUrl);

            if (bodyObj != null)
            {
                var json = JsonConvert.SerializeObject(bodyObj);
                var body = new StringContent(json);
                body.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                message.Content = body;
            }

            var response = await client.SendAsync(message);

            return new ApiResult(response);
        }
    }
}