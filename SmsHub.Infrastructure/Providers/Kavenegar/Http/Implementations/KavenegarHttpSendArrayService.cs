using SmsHub.Domain.Providers.Kavenegar.Constants;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Request;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using KavenegarRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations
{
    public class KavenegarHttpSendArrayService : IKavenegarHttpSendArrayService
    {
        private readonly IRestClient _restClient;
        public KavenegarHttpSendArrayService(IRestClient restClient)
        {
            _restClient = restClient;
        }
        public async Task<ResponseGeneric<List<ArraySendDto>>> Send(KavenegarRequest.ArraySendDto arraySendDto, string apiKey)
        {
            var uri = new Literals(apiKey).ArraySendUri;
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            var formDictionary = new Dictionary<string, ICollection<string>>
            {
                [nameof(arraySendDto.Receptor)] = arraySendDto.Receptor,
                [nameof(arraySendDto.Sender)] = arraySendDto.Sender,
                [nameof(arraySendDto.Message)] = arraySendDto.Message,
                [nameof(arraySendDto.LocalMessageIds)] = arraySendDto.LocalMessageIds.Select(l => l.ToString()).ToList(),
            };
            request.AddFormBody(formDictionary);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<ArraySendDto>>>(request);
            return response;
        }
    }
}
