using SmsHub.Domain.Constants;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Template.Queries.Contracts
{
    public interface ITemplateQueryService
    {
        Task<ICollection<Entities.Template>> Get();
        Task<Entities.Template> Get(ProviderEnum id);
    }
}
