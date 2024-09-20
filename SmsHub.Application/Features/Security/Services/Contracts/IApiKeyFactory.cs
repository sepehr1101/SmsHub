using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Services.Contracts
{
    public interface IApiKeyFactory
    {
        Task<ApiKeyAndHash> Create();
    }
}