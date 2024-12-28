using SmsHub.Domain.Features.Security.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IServerUserGetAllHandler
    {
        Task<ICollection<GetServerUserDto>> Handle();
    }
}
