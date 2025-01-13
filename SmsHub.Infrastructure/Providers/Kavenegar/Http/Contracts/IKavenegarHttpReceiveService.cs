using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using KaveRequest= SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts
{
    public interface IKavenegarHttpReceiveService
    {
        Task<List<ReceiveDto>> Trigger(KaveRequest.ReceiveDto receiveDto, string apiKey);
    }
}
