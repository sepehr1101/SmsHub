using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IUserLineGetByUserIdHandler
    {
        Task<ICollection<GetUserLineByUserIdDto>> Handle(Guid userId, CancellationToken cancellationToken);
    }
}
