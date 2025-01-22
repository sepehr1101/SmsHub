using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IRoleGetAllHandler
    {
        Task<ICollection<GetRoleDto>> Handle();
    }
}
