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
        private readonly IValidator<DeleteTemplateCategoryDto> _validator;
        public TemplateCategoryDeleteHandler(
            IMapper mapper,
            ITemplateCategoryCommandService templateCategoryCommandService,
            ITemplateCategoryQueryService templateCategoryQueryService,
            IValidator<DeleteTemplateCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateCategoryCommandService = templateCategoryCommandService;
            _templateCategoryCommandService.NotNull(nameof(templateCategoryCommandService));

            _templateCategoryQueryService = templateCategoryQueryService;
            _templateCategoryQueryService.NotNull(nameof(templateCategoryQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteTemplateCategoryDto deleteTemplateCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteTemplateCategoryDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var templateCategory = await _templateCategoryQueryService.Get(deleteTemplateCategoryDto.Id);
            _templateCategoryCommandService.Delete(templateCategory);
        }
    }
}
