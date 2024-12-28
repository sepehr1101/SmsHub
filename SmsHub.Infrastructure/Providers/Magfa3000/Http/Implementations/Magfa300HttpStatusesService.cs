using SmsHub.Domain.Providers.Magfa3000.Constants;
using magfaResponse = SmsHub.Domain.Providers.Magfa3000.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using SmsHub.Infrastructure.BaseHttp.Authenticators;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Implementations
{
    public class Magfa300HttpStatusesService : IMagfa300HttpStatusesService
    {
        private readonly IRestClient _restClient;

        public Magfa300HttpStatusesService(IRestClient httpClient)
        {
            _restClient = httpClient;
        }

        public async Task<magfaResponse.StatusesDto> GetStatuses(string domain, string username, string password, ICollection<long> id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Literals.GettatusesUri(id));
            return await Implement(domain, username, password, request);
        }

        public async Task<magfaResponse.StatusesDto> GetStatuses(string domain, string username, string password, long id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Literals.GettatusesUri(id));
            return await Implement(domain,username,password,request);
        }

        //todo: change Implement Method Name
        private async Task<magfaResponse.StatusesDto> Implement(string domain, string username, string password, HttpRequestMessage request)
        {
            request.AddBasicAuthentication($"{domain}/{username}", password);
            var response = await _restClient.Create(request.RequestUri).Execute<magfaResponse.StatusesDto>(request);
            return response;
        }
    }
}
