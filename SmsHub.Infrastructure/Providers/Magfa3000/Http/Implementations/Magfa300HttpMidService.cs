using SmsHub.Domain.Providers.Magfa3000.Constants;
using SmsHub.Infrastructure.BaseHttp.Authenticators;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Client.Implementation;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Implementations
{
    public class Magfa300HttpMidService : IMagfa300HttpMidService
    {
        private readonly IRestClient _restClient;

        public Magfa300HttpMidService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<MagfaRequest.MidDto> GetMid(string domain, string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Literals().MidUri);
            request.AddBasicAuthentication($"{domain}/{username}", password);
            var response = await _restClient.Create(request.RequestUri).Execute<MagfaRequest.MidDto>();
            return response;
        }
    }
}
