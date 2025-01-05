using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IServerUserGetByIdHandler
    {
        Task<GetServerUserDto> Handle(IntId id);
    }
}
