using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KavenegarRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpStatusService: IKavenegarHttpStatusService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpStatusService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ResponseGeneric<List<StatusDto>>> Trigger(KavenegarRequest.StatusDto statusDto, string apiKey)
        {
            var uri = new Literals(apiKey).StatusUri;
            var request=new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddQuery(statusDto);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<StatusDto>>>(request);
            return response;
        }
    }
}
