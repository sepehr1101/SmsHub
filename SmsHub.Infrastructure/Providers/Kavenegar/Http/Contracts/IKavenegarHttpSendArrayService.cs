using SmsHub.Domain.Providers.Kavenegar.Entities.Base;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts
{
    public interface IKavenegarHttpSendArrayService
    {
        Task<ResponseGeneric<List<Domain.Providers.Kavenegar.Entities.Responses.ArraySendDto>>> Send(Domain.Providers.Kavenegar.Entities.Requests.ArraySendDto arraySendDto, string apiKey);
    }
}