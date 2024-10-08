using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Template.Queries.Contracts
{
    public interface ITemplateCategoryQueryService
    {
        Task<ICollection<TemplateCategory>> Get();
        Task<TemplateCategory> Get(int id);
    }
}
