using SmsHub.Common.Extensions;
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
        public async Task<ResponseGeneric<List<ArraySendDto>>> Trigger(KavenegarRequest.ArraySendDto arraySendDto, string apiKey)
        {
            arraySendDto.NotNull(nameof(arraySendDto));
            var uri = new Literals(apiKey).ArraySendUri;
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            var formDictionary = new Dictionary<string, object>
            {                
                { nameof(arraySendDto.Receptor).ToLower() ,arraySendDto.Receptor },
                { nameof(arraySendDto.Sender).ToLower() , arraySendDto.Sender },
                { nameof(arraySendDto.Message).ToLower() , arraySendDto.Message }               
            };
            if (arraySendDto.LocalMessageIds?.Any()==true)
            {
                formDictionary.Add(nameof(arraySendDto.LocalMessageIds).ToLower(), arraySendDto.LocalMessageIds.Select(m=> Int64.Parse(m.ToString())));
            }    
            await request.AddFormBodyUrlEncoded(formDictionary);
            var response = await _restClient.Create(request.RequestUri).Execute<ResponseGeneric<List<ArraySendDto>>>(request);
            return response;
        }
    }
}
