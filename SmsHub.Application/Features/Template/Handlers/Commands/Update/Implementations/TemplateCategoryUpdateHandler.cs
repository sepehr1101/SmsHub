using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Update.Implementations
{
    public class TemplateCategoryUpdateHandler : ITemplateCategoryUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCategoryQueryService _templateCategoryQueryService;
        private readonly IValidator<UpdateTemplateCategoryDto> _validator;
        public TemplateCategoryUpdateHandler(
            IMapper mapper,
            ITemplateCategoryQueryService templateCategoryQueryService,
            IValidator<UpdateTemplateCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateCategoryQueryService = templateCategoryQueryService;
            _templateCategoryQueryService.NotNull(nameof(templateCategoryQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateTemplateCategoryDto updateTemplateCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateTemplateCategoryDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var templateCategory = await _templateCategoryQueryService.Get(updateTemplateCategoryDto.Id);
            _mapper.Map(updateTemplateCategoryDto, templateCategory);
        }
    }
}
