using SmsHub.Domain.Providers.Magfa3000.Entities.Responses;
using MagfaRequest= SmsHub.Domain.Providers.Magfa3000.Entities.Requests;


namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa3000HttpBalanceService
    {
        Task<List<BalanceDto>> balance(MagfaRequest.BalanceDto balanceDto, string spiKey);
    }
}
