using FluentValidation;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Validations
{
    internal class ContactCategoryUpdateValidator:AbstractValidator<UpdateContactCategoryDto>
    {
        public ContactCategoryUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 255);
            RuleFor(x => x.Description).MaximumLength(1023).When(o => o.Description != null);
            RuleFor(x => x.Css).NotEmpty().MaximumLength(1023);
        }
    }
}
