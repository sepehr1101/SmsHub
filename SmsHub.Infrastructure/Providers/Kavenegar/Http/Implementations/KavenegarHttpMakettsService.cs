using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KavenegarRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpMakettsService:IKavenegarHttpMakettsService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpMakettsService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ResponseGeneric<List<MakettsDto>>> Send(KavenegarRequest.MakettsDto makettsDto, string apiKey)
        {
            var uri = new Literals(apiKey).MakettsUri;
            var request=new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddQuery(makettsDto);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<MakettsDto>>>(request);
            return response;
        }
    }
}
