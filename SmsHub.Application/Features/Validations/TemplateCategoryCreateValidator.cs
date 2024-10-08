using FluentValidation;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Validations
{
    internal class TemplateCategoryCreateValidator:AbstractValidator<CreateTemplateCategoryDto>
    {
        public TemplateCategoryCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
            RuleFor(x=>x.Description).MaximumLength(255).When(o=>o.Description!=null);
        }

    }
}
