using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using KavenegarRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpSendSimpleService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpSendSimpleService(IRestClient restClient)
        {
            _restClient = restClient;
        }
        public async Task<ResponseGeneric<SimpleSendDto>> Send(KavenegarRequest.SimpleSendDto simpleSendDto, string apiKey)
        {
            var uri = new Literals(apiKey).SimpleSendUri;
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<SimpleSendDto>>(request);
            return response;
        }
    }
}
