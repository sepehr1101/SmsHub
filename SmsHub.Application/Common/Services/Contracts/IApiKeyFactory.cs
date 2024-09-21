using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Common.Services.Contracts
{
    public interface IApiKeyFactory
    {
        Task<ApiKeyAndHash> Create(string username);
    }
}