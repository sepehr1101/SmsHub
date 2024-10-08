using FluentValidation;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Validations
{
    internal class ContactNumberCategoryUpdateValidator:AbstractValidator<UpdateContactNumberCategoryDto>
    {
        public ContactNumberCategoryUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Css).NotEmpty().MaximumLength(1023);
        }
    }
}
