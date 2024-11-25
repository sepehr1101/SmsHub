using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Contact.Validations
{
    internal class ContactNumberCategoryCreateValidator:AbstractValidator<CreateContactNumberCategoryDto>
    {
        public ContactNumberCategoryCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255)
                .WithMessage(MessageResources.ItemNotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);

            RuleFor(x=>x.Css).NotEmpty().MaximumLength(1023)
                .WithMessage(MessageResources.ItemNotMoreThan128)
                .WithMessage(MessageResources.ItemNotNull);
        }
    }
}
