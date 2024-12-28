using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using MagfaResponse = SmsHub.Domain.Providers.Magfa3000.Entities.Responses;
using SmsHub.Domain.Providers.Magfa3000.Constants;
using SmsHub.Infrastructure.BaseHttp.Authenticators;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Domain.Providers.Magfa3000.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Implementations
{
    public class Magfa300HttpSendService : IMagfa300HttpSendService
    {
        private readonly IRestClient _restClient;

        public Magfa300HttpSendService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<MagfaResponse.SendDto> SendMessage(string domain, string username, string password, SendDto value)
        {
           var  request = new HttpRequestMessage(HttpMethod.Post,  Literals.SendUri);
            request.AddBasicAuthentication($"{domain}/{username}", password);
            request.AddBody(value);

            var response = await _restClient.Create(request.RequestUri).Execute<MagfaResponse.SendDto>(request);
            return response;
        }
    }
}
