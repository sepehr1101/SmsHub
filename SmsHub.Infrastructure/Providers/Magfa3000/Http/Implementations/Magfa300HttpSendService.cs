using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using SmsHub.Domain.Providers.Magfa3000.Entities.Responses;
using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;
using SmsHub.Domain.Providers.Magfa3000.Constants;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Implementations
{
    public class Magfa300HttpSendService : IMagfa300HttpSendService
    {
        private readonly IRestClient _restClient;

        public Magfa300HttpSendService(IRestClient restClient)
        {
            _restClient = restClient;
        }

       public async Task<MagfaRequest.SendDto> SendMessage(SendDto sendDto)
        {
            var request= new HttpRequestMessage(HttpMethod.Get,new Literals().SendUri);
            var response = await _restClient.Create(request.RequestUri).Execute<MagfaRequest.SendDto>();
            return response;
        }
    }
}
