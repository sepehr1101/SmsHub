using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Validations
{
    public class ContactNumberCategoryUpdateValidator : AbstractValidator<UpdateContactNumberCategoryDto>
    {
        public ContactNumberCategoryUpdateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x => x.Css)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(1023).WithMessage(MessageResources.ItemNotMoreThan1023);
        }
    }
}
