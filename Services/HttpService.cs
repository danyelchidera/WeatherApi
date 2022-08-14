using Contracts;
using Utilities;
using System.Net.Http;
using Utilities.WeatherResponseModel;
using System.Text.Json;
using Newtonsoft.Json;

namespace Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClient;

        public HttpService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> SendGetAsync<T>(RequestParameters request)
        {
            var client = _httpClient.CreateClient();

            HttpRequestMessage message = new HttpRequestMessage();

            message.RequestUri = new Uri(String.Format(request.Url, request.City, request.ApiKey));
            message.Method = HttpMethod.Get;
            message.Headers.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Clear();

            HttpResponseMessage response = await client.SendAsync(message);
            var responseContent = await response.Content.ReadAsStringAsync();
      
            var deserialisedResponse = JsonConvert.DeserializeObject<T>(responseContent);

            return deserialisedResponse;
        }
    }
}