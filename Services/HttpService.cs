using Contracts;
using Utilities;
using System.Net.Http;
using Utilities.WeatherResponseModel;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net;

namespace Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClient;

        public HttpService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(bool status, string result, HttpStatusCode statusCode)> SendGetAsync(WeatherDataRequestParams request)
        {
            var client = _httpClient.CreateClient();

            HttpRequestMessage message = new HttpRequestMessage();

            message.RequestUri = new Uri(String.Format(request.Url, request.City, request.ApiKey));
            message.Method = HttpMethod.Get;
            message.Headers.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Clear();

            HttpResponseMessage response = await client.SendAsync(message);
            var responseContent = await response.Content.ReadAsStringAsync();

            return (status: response.IsSuccessStatusCode, result: responseContent, statusCode: response.StatusCode);
        }
    }
}