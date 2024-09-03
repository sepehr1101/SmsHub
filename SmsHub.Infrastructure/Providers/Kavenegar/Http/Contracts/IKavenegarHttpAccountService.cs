using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts
{
    public interface IKavenegarHttpAccountService
    {
        Task<ResponseGeneric<InfoDto>> GetAccountInfo(string apiKey);
    }
}
