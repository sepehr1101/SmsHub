using AutoMapper;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Queries.Implementations
{
    public  class TemplateCategoryGetSingleHandler: ITemplateCategoryGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateQueryService _templateQueryService;
        public TemplateCategoryGetSingleHandler(IMapper mapper, ITemplateQueryService templateQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateQueryService = templateQueryService;
            _templateQueryService.NotNull(nameof(templateQueryService));
        }
        public async Task<GetTemplateCategoryDto> Handle(int Id)
        {
            var templateCategory = await _templateQueryService.Get(Id);
            return _mapper.Map<GetTemplateCategoryDto>(templateCategory);
        }
    }
}
