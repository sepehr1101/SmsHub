using SmsHub.Domain.Providers.Kavenegar.Entities.Base;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class StatusByMessageIdDto : ResponseBase
    {
        public long LocalId { get; set; }
    }
}
