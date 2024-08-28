using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KaveRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpCancelService:IKavenegarHttpCancelService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpCancelService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ResponseGeneric<List<CancelDto>>> Send(KaveRequest.CancelDto cancelDto, string apiKey)
        {
            var uri = new Literals(apiKey).CancelUri;
            var request=new HttpRequestMessage(HttpMethod.Post, uri);
            request.AddQuery(cancelDto);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<CancelDto>>>(request);
            return response;
        }
    }
}
