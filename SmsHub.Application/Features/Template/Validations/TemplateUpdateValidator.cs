using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Template.Validations
{
    public class TemplateUpdateValidator : AbstractValidator<UpdateTemplateDto>
    {
        public TemplateUpdateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x => x.Expression).NotEmpty().WithMessage(MessageResources.ItemNotNull);

        }
    }
}
