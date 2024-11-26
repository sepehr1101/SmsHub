using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Validations
{
    public class ContactUpdateValidator:AbstractValidator<UpdateContactDto>
    {
        public ContactUpdateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);
        }
    }
}
