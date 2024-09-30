using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Queries.Contracts
{
    public interface IOperationTypeQueryService
    {
        Task<ICollection<OperationType>> Get();
        Task<OperationType> Get(ProviderEnum id);
    }
}
