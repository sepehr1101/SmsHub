using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Contact.Validations
{
    public class ContactNumberCreateValidator:AbstractValidator<CreateContactNumberDto>
    {
        public ContactNumberCreateValidator()
        {
            RuleFor(x => x.Number).NotEmpty().MaximumLength(255)
                .WithMessage(MessageResources.ItemNotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);
        }
    }
}
