using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KavenegarRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpCountInboxService:IKavenegarHttpCountInboxService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpCountInboxService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ResponseGeneric<List<CountInboxDto>>> Trigger(KavenegarRequest.CountInboxDto countInboxDto, string apiKey)
        {
            var uri = new Literals(apiKey).CountInboxUri;
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddQuery(countInboxDto);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<CountInboxDto>>>(request);
            return response;
        }
    }
}
