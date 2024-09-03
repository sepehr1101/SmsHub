using SmsHub.Common;
using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpAccountService: IKavenegarHttpAccountService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpAccountService(IRestClient restClient)
        {
            _restClient = restClient;
            _restClient.NotNull();
        }
        public async Task<ResponseGeneric<InfoDto>> Trigger(string apiKey)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Literals(apiKey).InfoUri);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<InfoDto>>(request);
            return response;
        }
    }
}
