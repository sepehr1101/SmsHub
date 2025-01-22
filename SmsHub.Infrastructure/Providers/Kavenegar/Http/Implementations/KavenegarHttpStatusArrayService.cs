using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KavenegarRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpStatusArrayService : IKavenegarHttpStatusArrayService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpStatusArrayService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ResponseGeneric<List<StatusDto>>> Trigger(ICollection<KavenegarRequest.StatusDto> statusListDto, string apiKey)
        {
            var uri = new Literals(apiKey).StatusUri;
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            //var statusListString = String.Join(",", statusListDto.Select(x => x.MessageId));
            
           // request.AddQuery("messageid"+statusListDto);
            request.AddQuery(statusListDto);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<StatusDto>>>(request);
            return response;
        }
    }
}

