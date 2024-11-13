using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Security.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IServerUserGetByApiKeyHandler
    {
        Task<GetServerUserDto> Handle(StringId apiKey); 
    }
}
