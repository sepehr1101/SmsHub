using SmsHub.Common.Extensions;
using SmsHub.Domain.Providers.Magfa3000.Constants;
using SmsHub.Domain.Providers.Magfa3000.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Authenticators;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Implementations
{
    public class Magfa300HttpBalanceService : IMagfa300HttpBalanceService
    {
        private readonly IRestClient _restClient;

        public Magfa300HttpBalanceService(IRestClient restClient)
        {
            _restClient = restClient;
            _restClient.NotNull();
        }

        public async Task<BalanceDto> GetBalances(string domain, string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Literals.BalanceUri);
            request.AddBasicAuthentication($"{username}/{domain}", password);
            var response = await _restClient.Create(request.RequestUri).Execute<BalanceDto>(request);

            return response;
        }
    }
}
