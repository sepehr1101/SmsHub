using SmsHub.Domain.Constants;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface IGetStatusSingleService
    {
      Task  Trigger(long messageDetailId, ProviderEnum providerId);
    }
}
