using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface IPermittedTimeQueryService
    {
        Task<ICollection<PermittedTime>> Get();
        Task<PermittedTime> Get(int id);
    }
}
