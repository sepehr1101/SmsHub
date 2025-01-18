using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Contracts
{
    public interface IUserLineCommandService
    {
        Task Add(UserLine userLine);
         Task Add(ICollection<UserLine> userLines);
        Task Delete(long userLineId);
    }
}
