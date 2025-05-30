﻿using SmsHub.Domain.Providers.Magfa3000.Constants;
using SmsHub.Infrastructure.BaseHttp.Authenticators;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using MagfaResponse = SmsHub.Domain.Providers.Magfa3000.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Implementations
{
    public class Magfa300HttpMidService : IMagfa300HttpMidService
    {
        private readonly IRestClient _restClient;

        public Magfa300HttpMidService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<MagfaResponse.MidDto> GetMid(string domain, string username, string password,long uid)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,  Literals.GetMidUri(uid));
            request.AddBasicAuthentication($"{username}/{domain}", password);
            var response = await _restClient.Create(request.RequestUri).Execute<MagfaResponse.MidDto>(request);
            return response;
        }
    }
}
