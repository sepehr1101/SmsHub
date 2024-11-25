using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Template.Validations
{
    internal class TemplateCategoryCreateValidator : AbstractValidator<CreateTemplateCategoryDto>
    {
        public TemplateCategoryCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255)
                .WithMessage(MessageResources.ItemNotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.Description).MaximumLength(255).When(o => o.Description != null)
                .WithMessage(MessageResources.ItemNotMoreThan255);
        }
    }
}
