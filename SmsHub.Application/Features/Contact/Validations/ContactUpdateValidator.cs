using FluentValidation;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Validations
{
    internal class ContactUpdateValidator:AbstractValidator<UpdateContactDto>
    {
        public ContactUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        }
    }
}
