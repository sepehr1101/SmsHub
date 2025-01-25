using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Queries.Implementations
{
    public class TemplateGetAllDictionaryHandler : ITemplateGetAllDictionaryHandler
    {
        private readonly ITemplateQueryService _templateQueryService;
        public TemplateGetAllDictionaryHandler(ITemplateQueryService templateQueryService)
        {
             _templateQueryService = templateQueryService;
            _templateQueryService.NotNull(nameof(templateQueryService));
        }
        public async Task<ICollection<TemplateDictionary>> Handle()
        {
            var result = await _templateQueryService.GetDictionary();
            return result;
        }
    }
}
