using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IUserLineGetByLineIdHandler
    {
        Task<ICollection<GetUserLineByLineIdDto>> Handle(int lineId, CancellationToken cancellationToken);
    }
}
