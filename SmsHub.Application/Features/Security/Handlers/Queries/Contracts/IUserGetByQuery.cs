using Gridify;
using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IUserGetByQuery
    {
        Task<ICollection<UserQueryDto>> Handle(GridifyQuery query, CancellationToken cancellationToken);
    }
}