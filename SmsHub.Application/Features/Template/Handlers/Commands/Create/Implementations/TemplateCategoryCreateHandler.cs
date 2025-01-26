using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Template.Commands.Contracts;
using SmsHub.Application.Features.Template.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using FluentValidation;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Create.Implementations
{
    public class TemplateCategoryCreateHandler : ITemplateCategoryCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCategoryCommandService _templateCategoryCommandService;
        private readonly IValidator<CreateTemplateCategoryDto> _validator;
        public TemplateCategoryCreateHandler(
            IMapper mapper, 
            ITemplateCategoryCommandService templateCategoryCommandService, 
            IValidator<CreateTemplateCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _templateCategoryCommandService = templateCategoryCommandService;
            _templateCategoryCommandService.NotNull(nameof(_templateCategoryCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateTemplateCategoryDto createTemplateCategoryDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createTemplateCategoryDto, cancellationToken);


            var templateCategory = _mapper.Map<Entities.TemplateCategory>(createTemplateCategoryDto);
            await _templateCategoryCommandService.Add(templateCategory);
        }
        private async Task CheckValidator(CreateTemplateCategoryDto createTemplateCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createTemplateCategoryDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}
