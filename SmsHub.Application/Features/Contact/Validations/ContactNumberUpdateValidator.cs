using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Validations
{
    public class ContactNumberUpdateValidator:AbstractValidator<UpdateContactNumberDto>
    {
        public ContactNumberUpdateValidator()
        {
            RuleFor(x => x.Number).NotEmpty().MaximumLength(255)
                .WithMessage(MessageResources.ItemNotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);
        }
    }
}
