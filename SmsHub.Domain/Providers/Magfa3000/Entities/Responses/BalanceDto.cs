using SmsHub.Domain.Providers.Magfa3000.Entities.Base;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class BalanceDto : ResponseBase
    {
        public long Balance { get; set; }
    }
}
