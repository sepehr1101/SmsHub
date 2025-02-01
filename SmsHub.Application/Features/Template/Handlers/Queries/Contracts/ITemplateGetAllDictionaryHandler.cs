using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Template.Handlers.Queries.Contracts
{
    public interface ITemplateGetAllDictionaryHandler
    {
        Task<ICollection<TemplateDictionary>> Handle();
    }
}
