using FluentValidation;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Validations
{
    internal class ContactNumberUpdateValidator:AbstractValidator<UpdateContactNumberDto>
    {
        public ContactNumberUpdateValidator()
        {
            RuleFor(x => x.Number).NotEmpty().MaximumLength(255);
        }
    }
}
