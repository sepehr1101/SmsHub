using FluentValidation;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Template.Validations
{
    public class TemplateCreateValidator : AbstractValidator<CreateTemplateDto>
    {
        public TemplateCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x => x.Expression).NotEmpty().WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.Parameters).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}
