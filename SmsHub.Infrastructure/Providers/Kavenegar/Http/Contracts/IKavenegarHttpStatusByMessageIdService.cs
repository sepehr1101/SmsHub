using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using KaveRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts
{
    public interface IKavenegarHttpStatusByMessageIdService
    {
        Task<ResponseGeneric<List<StatusByMessageIdDto>>> Trigger(KaveRequest.StatusByMessageIdDto statusByMessageId,string apiKey);
    }
}
