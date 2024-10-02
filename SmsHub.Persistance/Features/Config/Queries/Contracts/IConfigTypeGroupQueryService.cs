using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface IConfigTypeGroupQueryService
    {
        Task<ICollection<ConfigTypeGroup>> Get();
        Task<ConfigTypeGroup> Get(int id);
    }
}
