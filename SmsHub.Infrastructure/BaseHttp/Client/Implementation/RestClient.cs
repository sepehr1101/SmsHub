using HttpClientToCurl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmsHub.Common.Extensions;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using System.Net.Http.Json;

namespace SmsHub.Infrastructure.BaseHttp.Client.Implementation
{
    public class RestClient : IRestClient
    {
        private HttpClient? _httpClient { get; set; } 

        private readonly IHttpClientFactory _httpClientFactory;
        
        public RestClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClientFactory.NotNull();
        }
        public RestClient Create(Uri url)
        {
            _httpClient = _httpClientFactory.CreateClient(url.AbsoluteUri);
            _httpClient.BaseAddress = url;
            
            return this;
        }

        public async Task<T?> Execute<T>(HttpRequestMessage requestMessage) where T : class
        {
            _httpClient.NotNull(nameof(_httpClient));
            HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);
            response.NotNull(nameof(response));
            T? content = await response?.Content?.ReadFromJsonAsync<T>();
            return content;
        }

        internal Task<T> Execute<T>()
        {
            throw new NotImplementedException();
        }
    }
}
