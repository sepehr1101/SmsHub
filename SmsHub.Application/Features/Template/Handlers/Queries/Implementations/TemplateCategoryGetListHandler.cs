using AutoMapper;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Queries.Implementations
{
    public class TemplateCategoryGetListHandler : ITemplateCategoryGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateQueryService _templateQueryService;
        public TemplateCategoryGetListHandler(IMapper mapper, ITemplateQueryService templateQueryService)
        {
            _mapper=mapper;
            _mapper.NotNull(nameof(mapper));
            
            _templateQueryService=templateQueryService;
            _templateQueryService.NotNull(nameof(templateQueryService));
        }
        public async Task<ICollection<GetTemplateCategoryDto>> Handle()
        {
            var templateCategories = await _templateQueryService.Get();
            return _mapper.Map<ICollection<GetTemplateCategoryDto>>(templateCategories);
        }
    }
}
