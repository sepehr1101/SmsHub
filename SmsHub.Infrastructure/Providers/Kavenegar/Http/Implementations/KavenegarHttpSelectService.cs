using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KavenegarRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpSelectService: IKavenegarHttpSelectService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpSelectService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ResponseGeneric<List<SelectDto>>> Send(KavenegarRequest.SelectDto selectDto, string apiKey)
        {
            var uri = new Literals(apiKey).SelectUri;
            var request=new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddQuery(selectDto);
            var response = await _restClient.Create(request.RequestUri).Execute< ResponseGeneric<List<SelectDto>>>(request);
            return response;
        }
    }
}
