using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Contact.Validations
{
    public class ContactCreateValidator : AbstractValidator<CreateContactDto>
    {
        public ContactCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);
        }
    }
}
