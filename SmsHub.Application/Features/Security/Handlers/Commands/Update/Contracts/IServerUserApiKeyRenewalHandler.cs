using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts
{
    public interface IServerUserApiKeyRenewalHandler
    {
        Task<ApiKeyAndHash> Handle(int id);
    }
}