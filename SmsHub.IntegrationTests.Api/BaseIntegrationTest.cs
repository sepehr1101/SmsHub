using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Text.Json;

namespace SmsHub.IntegrationTests.Api
{
    public abstract class BaseIntegrationTest
    : IClassFixture<_TestEnvironmentWebApplicationFactory>, IDisposable
    {
        public BaseIntegrationTest(_TestEnvironmentWebApplicationFactory factory)
        {
            _serviceScope = factory.Services.CreateScope();
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7221");
        }

        protected IServiceScope _serviceScope;
        protected HttpClient _httpClient;
        private JsonSerializerOptions _serializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task<TData?> GetAsync<TData>(string url)
        {
            var result = await _httpClient.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<TData>(content, _serializerOptions);

            return data;
        }

        public async Task<TResult?> PostAsync<TData, TResult>(string url, TData data)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(data),
                Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync(url, stringContent);
            string content = await result.Content.ReadAsStringAsync();
            var returnData = JsonSerializer.Deserialize<TResult>(content, _serializerOptions);

            return returnData;
        }
        
        public async Task<string> PostAsyncWithoutDeserialize<TData>(string url, TData data)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(data),
                Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync(url, stringContent);
            string content = await result.Content.ReadAsStringAsync();
            return content;
        }

        public void Dispose()
        {
            _serviceScope.Dispose();
            _httpClient.Dispose();
        }
    }
}
