using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IUserGetAllHandler
    {
        Task<ICollection<UserQueryDto>> Handle(CancellationToken cancellationToken);
    }
}