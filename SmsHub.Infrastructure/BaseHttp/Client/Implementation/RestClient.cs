using SmsHub.Infrastructure.BaseHttp.Client.Contracts;

namespace SmsHub.Infrastructure.BaseHttp.Client.Implementation
{
    internal class RestClient : IRestClient
    {
        private HttpClient? _httpClient { get; set; } 

        private readonly IHttpClientFactory _httpClientFactory;
        
        public RestClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public RestClient Create(string url)
        {
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(url);
            
            return this;
        }
    }
}
