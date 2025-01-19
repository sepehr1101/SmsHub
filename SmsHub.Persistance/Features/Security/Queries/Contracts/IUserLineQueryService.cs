using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Queries.Contracts
{
    public interface IUserLineQueryService
    {
        Task<UserLine> GetById(long Id);
        Task<ICollection<GetUserLineByUserIdDto>> GetUserLinesByUserId(Guid userId);

        Task<ICollection<GetUserLineByLineIdDto>> GetUserLinesByLineId(int LineId);
    }
}
