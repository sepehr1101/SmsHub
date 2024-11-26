using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Template.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Template.Commands.Contracts;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Delete.Implementations
{
    public class TemplateCategoryDeleteHandler : ITemplateCategoryDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCategoryCommandService _templateCategoryCommandService;
        private readonly ITemplateCategoryQueryService _templateCategoryQueryService;
        public TemplateCategoryDeleteHandler(
            IMapper mapper,
            ITemplateCategoryCommandService templateCategoryCommandService,
            ITemplateCategoryQueryService templateCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateCategoryCommandService = templateCategoryCommandService;
            _templateCategoryCommandService.NotNull(nameof(templateCategoryCommandService));

            _templateCategoryQueryService = templateCategoryQueryService;
            _templateCategoryQueryService.NotNull(nameof(templateCategoryQueryService));
        }
        public async Task Handle(DeleteTemplateCategoryDto deleteTemplateCategoryDto, CancellationToken cancellationToken)
        {
            var templateCategory = await _templateCategoryQueryService.Get(deleteTemplateCategoryDto.Id);
            _templateCategoryCommandService.Delete(templateCategory);
        }
    }
}
