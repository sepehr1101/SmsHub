using AutoMapper;
using SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Update.Implementations
{
    public class UpdateTemplateCategoryHandler: IUpdateTemplateCategoryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCategoryQueryService _templateCategoryQueryService;
        public UpdateTemplateCategoryHandler(IMapper mapper, ITemplateCategoryQueryService templateCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateCategoryQueryService = templateCategoryQueryService;
            _templateCategoryQueryService.NotNull(nameof(templateCategoryQueryService));
        }
        public async Task Handle(UpdateTemplateCategoryDto updateTemplateCategoryDto, CancellationToken cancellationToken)
        {
            var templateCategory = await _templateCategoryQueryService.Get(updateTemplateCategoryDto.Id);
            _mapper.Map(updateTemplateCategoryDto, templateCategory);
        }
    }
}
