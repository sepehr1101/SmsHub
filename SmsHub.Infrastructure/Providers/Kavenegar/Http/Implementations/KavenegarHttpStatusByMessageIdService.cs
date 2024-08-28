using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KavenegarRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;


namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpStatusByMessageIdService : IKavenegarHttpStatusByMessageIdService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpStatusByMessageIdService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ResponseGeneric<List<StatusByMessageIdDto>>> Send(KavenegarRequest.StatusByMessageIdDto statusByMessageIdDto, string apiKey)
        {
            var uri = new Literals(apiKey).StatusByMessageIdUri;
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddQuery(statusByMessageIdDto);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<StatusByMessageIdDto>>>(request);
            return response;
        }
    }
}
