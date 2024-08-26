using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KavenegarRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpSendSimpleService : IKavenegarHttpSendSimpleService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpSendSimpleService(IRestClient restClient)
        {
            _restClient = restClient;
        }
        public async Task<ResponseGeneric<List<SimpleSendDto>>> Send(KavenegarRequest.SimpleSendDto simpleSendDto, string apiKey)
        {
            var uri = new Literals(apiKey).SimpleSendUri;
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddQuery(simpleSendDto);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<SimpleSendDto>>>(request);
            return response;
        }
    }
}
