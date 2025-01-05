using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Contracts
{
    public interface IUserLoginCommandService
    {
        Task Add(UserLogin userLogin);
    }
}