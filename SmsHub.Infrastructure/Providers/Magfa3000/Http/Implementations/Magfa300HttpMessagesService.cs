using SmsHub.Domain.Providers.Magfa3000.Constants;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using MagfaResponse = SmsHub.Domain.Providers.Magfa3000.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Authenticators;
using SmsHub.Domain.Providers.Magfa3000.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Implementations
{
    public class Magfa300HttpMessagesService : IMagfa300HttpMessagesService
    {
        private readonly IRestClient _restClient;

        public Magfa300HttpMessagesService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<MagfaResponse.ReceivedMessagesDto> GetMessages(string domain, string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Literals.MessagesUri);
            request.AddBasicAuthentication($"{domain}/{username}", password);
            var response = await _restClient.Create(request.RequestUri).Execute<MagfaResponse.ReceivedMessagesDto>(request);
            return response;
        }
    }
}
