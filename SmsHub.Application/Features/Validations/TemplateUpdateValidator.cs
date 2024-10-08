using FluentValidation;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Validations
{
    internal class TemplateUpdateValidator:AbstractValidator<UpdateTemplateDto>
    {
        public TemplateUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Expression).NotEmpty();
            RuleFor(x => x.Parameters).NotEmpty();
        }
    }
}
