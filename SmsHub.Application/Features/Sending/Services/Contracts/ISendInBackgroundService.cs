using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISendInBackgroundService
    {
        Task Trigger(Guid messageHolderId, ProviderEnum providerId);
    }
}