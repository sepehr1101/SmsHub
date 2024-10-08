using FluentValidation;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Validations
{
    internal class TemplateCreateValidator : AbstractValidator<CreateTemplateDto>
    {
        public TemplateCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Expression).NotEmpty();
            RuleFor(x=>x.Parameters).NotEmpty();
        }
    }
}
