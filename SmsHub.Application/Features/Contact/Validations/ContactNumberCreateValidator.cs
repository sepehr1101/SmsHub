using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Contact.Validations
{
    public class ContactNumberCreateValidator : AbstractValidator<CreateContactNumberDto>
    {
        public ContactNumberCreateValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);
        }
    }
}
