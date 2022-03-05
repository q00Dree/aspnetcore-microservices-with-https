using Sample.SecondService.HttpApiConnector.Exceptions;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sample.SecondService.HttpApiConnector
{
    public class SecondServiceHttpApiConnector : ISecondServiceHttpApiConnector
    {
        private readonly HttpClient _httpClient;

        public SecondServiceHttpApiConnector(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> HealthCheckAsync()
        {
            string? content = null;

            HttpResponseMessage response;

            try
            {
                response = await _httpClient.GetAsync($"/health");
            }
            catch (HttpRequestException ex)
            {
                throw new SecondApiServiceException("SecondApiService is not responding", ex, ex.StatusCode);
            }

            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
            {
                throw new SecondApiServiceTimeoutException($"\"Request Timeout\" while trying to get response. Status code={response.StatusCode}.");
            }

            return content;
        }
    }
}
