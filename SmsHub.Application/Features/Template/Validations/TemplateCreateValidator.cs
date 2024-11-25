using FluentValidation;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Template.Validations
{
    internal class TemplateCreateValidator : AbstractValidator<CreateTemplateDto>
    {
        public TemplateCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255)
                .WithMessage(MessageResources.ItemNotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.Expression).NotEmpty().WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.Parameters).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}
