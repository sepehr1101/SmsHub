using SmsHub.Domain.Providers.Magfa3000.Constants;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;
using SmsHub.Domain.Providers.Magfa3000.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Implementations
{
    public class Magfa300HttpMessagesService:IMagfa300HttpMessagesService
    {
        private readonly IRestClient _restClient;

        public Magfa300HttpMessagesService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<MagfaRequest.ReceivedMessagesDto> Message(ReceivedMessagesDto receivedMessagesDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,new Literals().MessagesUri);
            var response = await _restClient.Create(request.RequestUri).Execute<MagfaRequest.ReceivedMessagesDto>();
            return response;
        }
    }
}
