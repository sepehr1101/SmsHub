using SmsHub.Common.Extensions;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Interceptors.Contracts;
using System.Net.Http.Json;

namespace SmsHub.Infrastructure.BaseHttp.Client.Implementation
{
    public class RestClient : IRestClient
    {
        private HttpClient? _httpClient { get; set; } 

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpInterceptor _x;
        private readonly IEnumerable<IHttpInterceptor> _interceptors;

        public RestClient(
            IHttpClientFactory httpClientFactory,
            IEnumerable<IHttpInterceptor> interceptors)
        {
            _httpClientFactory = httpClientFactory;
            _httpClientFactory.NotNull();

            _interceptors = interceptors;
        }
        public RestClient Create(Uri url)
        {
            _httpClient = _httpClientFactory.CreateClient(url.AbsoluteUri);
            _httpClient.BaseAddress = url;
            
            return this;
        }
        public async Task<T?> Execute<T>(HttpRequestMessage requestMessage) where T : class
        {
            if(_httpClient is null)
            {
                throw new Exception("null http client, use create method before execute");
            }
            foreach (var interceptor in _interceptors)
            {
                await interceptor.OnRequestAsync(requestMessage);
            }

            _httpClient.NotNull(nameof(_httpClient));
            HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);
            response.NotNull(nameof(response));
           
            foreach (var interceptor in _interceptors)
            {
                await interceptor.OnResponseAsync(response);
            }
            response.EnsureSuccessStatusCode();
            ContentType contentType = response.Content.Headers.ContentType?.MediaType;           
            return contentType switch
            {
                _ when contentType.Equals(ContentType.Json) => await response.Content.ReadFromJsonAsync<T>(),
                _ when contentType.Equals(ContentType.Plain) => (T)(object)await response.Content.ReadAsStringAsync(),
                _ when contentType.Equals(ContentType.Binary) => (T)(object)await response.Content.ReadAsByteArrayAsync(),
                _ => throw new NotSupportedException($"Unsupported Content-Type: {contentType}")
            };
        }

        internal Task<T> Execute<T>()
        {
            throw new NotImplementedException();
        }
    }
}
