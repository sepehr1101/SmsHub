using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KaveRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpReceiveService : IKavenegarHttpReceiveService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpReceiveService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ResponseGeneric<List<ReceiveDto>>> Trigger(KaveRequest.ReceiveDto receiveDto, string apiKey)
        {
            var uri = new Literals(apiKey).ReceiveUri;
            var request=new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddQuery(receiveDto);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<ReceiveDto>>>(request);
            return response;
        }
    }
}
