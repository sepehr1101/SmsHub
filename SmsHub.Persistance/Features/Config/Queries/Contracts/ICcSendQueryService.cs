using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface ICcSendQueryService
    {
        Task<ICollection<CcSend>> Get();
        Task<CcSend> Get(int id);
    }
}
