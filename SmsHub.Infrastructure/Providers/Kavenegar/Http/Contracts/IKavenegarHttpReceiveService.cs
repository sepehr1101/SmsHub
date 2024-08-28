using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using KaveRequest= SmsHub.Domain.Providers.Kavenegar.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts
{
    public interface IKavenegarHttpReceiveService
    {
        Task<ResponseGeneric<List<ReceiveDto>>> Send(KaveRequest.ReceiveDto receiveDto, string apiKey);
    }
}
