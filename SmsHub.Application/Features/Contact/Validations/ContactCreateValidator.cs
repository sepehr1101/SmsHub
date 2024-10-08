using FluentValidation;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Contact.Validations
{
    internal class ContactCreateValidator:AbstractValidator<CreateContactDto>
    {
        public ContactCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        }
    }
}
