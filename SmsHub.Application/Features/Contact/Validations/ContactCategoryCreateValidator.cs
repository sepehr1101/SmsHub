using FluentValidation;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Contact.Validations
{
    internal class ContactCategoryCreateValidator:AbstractValidator<CreateContactCategoryDto>
    {
        public ContactCategoryCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 255);
            RuleFor(x=>x.Description).MaximumLength(1023).When(o=>o.Description!=null);
            RuleFor(x => x.Css).NotEmpty().MaximumLength(1023);
        }
    }
}
