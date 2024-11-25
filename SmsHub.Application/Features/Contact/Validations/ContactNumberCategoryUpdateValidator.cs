using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Validations
{
    internal class ContactNumberCategoryUpdateValidator:AbstractValidator<UpdateContactNumberCategoryDto>
    {
        public ContactNumberCategoryUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255)
                .WithMessage(MessageResources.ItemNotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.Css).NotEmpty().MaximumLength(1023)
                .WithMessage(MessageResources.ItemNotMoreThan1023)
                .WithMessage(MessageResources.ItemNotNull);
        }
    }
}
