using SmsHub.Domain.Providers.Magfa3000.Constants;
using SmsHub.Domain.Providers.Magfa3000.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Implementations
{
    public class Magfa3000HttpBalanceService:IMagfa3000HttpBalanceService
    {

        //todo : private string _baseAndKey { get { return $"{BaseUrl}/"; } }
        //{UserName}/{Domain}:{Password}/  are in Header request


        //I do : all prop-> private to public
        private readonly IRestClient _restClient;
        private readonly Literals _literals;
        public Magfa3000HttpBalanceService(IRestClient restClient, Literals literals)
        {
            _restClient = restClient;
            _literals = literals;
        }
        public async Task<List<BalanceDto>> balance(MagfaRequest.BalanceDto balanceDto, string spiKey)
        {
            var uri = _literals.BalanceUri;
            var password = _literals.Password;
            var userName = _literals.UserName;
            var domain = _literals.Domain;

            var credentials = $"{userName}/{domain}:{password}";
            var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

            var response = await _restClient.Create(request.RequestUri).Execute<List<BalanceDto>>(request);
            return response;
        }
    }
}
