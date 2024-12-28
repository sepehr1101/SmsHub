using AutoMapper;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Queries.Implementations
{
    public  class TemplateCategoryGetSingleHandler: ITemplateCategoryGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCategoryQueryService _templateCategoryQueryService;
        public TemplateCategoryGetSingleHandler(
            IMapper mapper,
            ITemplateCategoryQueryService templateCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateCategoryQueryService = templateCategoryQueryService;
            _templateCategoryQueryService.NotNull(nameof(templateCategoryQueryService));
        }
        public async Task<GetTemplateCategoryDto> Handle(IntId Id)
        {
            var templateCategory = await _templateCategoryQueryService.Get(Id.Id);
            return _mapper.Map<GetTemplateCategoryDto>(templateCategory);
        }
    }
}
