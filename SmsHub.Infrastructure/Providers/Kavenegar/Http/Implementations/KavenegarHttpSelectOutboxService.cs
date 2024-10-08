using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KaveRequest= SmsHub.Domain.Providers.Kavenegar.Entities.Requests;


namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpSelectOutboxService:IKavenegarHttpSelectOutboxService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpSelectOutboxService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ResponseGeneric<List<SelectOutboxDto>>> Trigger(KaveRequest.SelectOutboxDto selectOutboxDto, string apiKey)
        {
            var uri = new Literals(apiKey).SelectOutboxUri;
            var request=new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddQuery(selectOutboxDto);
            var response =await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<SelectOutboxDto>>>(request);
            return response;
        }
    }
}
