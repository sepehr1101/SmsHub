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
        private readonly ITemplateCategoryQueryService _templateCategoryQueryService;
        public TemplateCategoryGetListHandler(IMapper mapper, ITemplateCategoryQueryService templateCategoryQueryService)
        {
            _mapper=mapper;
            _mapper.NotNull(nameof(mapper));
            
            _templateCategoryQueryService=templateCategoryQueryService;
            _templateCategoryQueryService.NotNull(nameof(templateCategoryQueryService));
        }
        public async Task<ICollection<GetTemplateCategoryDto>> Handle()
        {
            var templateCategories = await _templateCategoryQueryService.Get();
            return _mapper.Map<ICollection<GetTemplateCategoryDto>>(templateCategories);
        }
    }
}
