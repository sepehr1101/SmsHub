using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Services.Implementations
{
    internal interface IApiKeyFactory
    {
        Task<ApiKeyAndHash> Create();
    }
}