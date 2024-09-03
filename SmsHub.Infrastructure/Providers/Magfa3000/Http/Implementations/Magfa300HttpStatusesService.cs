using SmsHub.Domain.Providers.Magfa3000.Constants;
using SmsHub.Domain.Providers.Magfa3000.Entities.Requests;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Implementations
{
    public class Magfa300HttpStatusesService: IMagfa300HttpStatusesService
    {
        private readonly IRestClient _restClient;

        public Magfa300HttpStatusesService(IRestClient httpClient)
        {
            _restClient = httpClient;
        }

    

        public async Task<Statuses> GetStatuses(StatusDto statuses)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Literals().StatusesUri);
            var response = await _restClient.Create(request.RequestUri).Execute<Statuses>();
            return response;
        }
    }
}
