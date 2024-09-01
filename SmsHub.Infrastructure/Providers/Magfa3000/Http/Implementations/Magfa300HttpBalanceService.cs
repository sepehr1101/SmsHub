using SmsHub.Common;
using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Magfa3000.Constants;
using SmsHub.Domain.Providers.Magfa3000.Entities.Responses;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<BalanceDto> GetBalance()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,new Literals().BalanceUri);
            var response = await _restClient.Create(request.RequestUri).Execute<BalanceDto>();

            return response;
        }
    }
}
