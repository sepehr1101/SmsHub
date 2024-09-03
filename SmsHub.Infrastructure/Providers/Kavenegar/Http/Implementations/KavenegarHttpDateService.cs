using SmsHub.Common;
using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpDateService : IKavenegarHttpDateService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpDateService(IRestClient restClient)
        {
            _restClient = restClient;
            _restClient.NotNull();
        }
        public async Task<ResponseGeneric<GetDateDto>> Trigger()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Literals().GetDateUrl);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<GetDateDto>>(request);
            return response;
        }
    }
}
