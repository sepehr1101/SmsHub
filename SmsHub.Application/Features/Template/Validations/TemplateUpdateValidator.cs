using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Template.Validations
{
    public class TemplateUpdateValidator : AbstractValidator<UpdateTemplateDto>
    {
        public TemplateUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255)
                .WithMessage(MessageResources.ItemNotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.Expression).NotEmpty().WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.Parameters).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}
