using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Validations
{
    public class ContactCategoryUpdateValidator:AbstractValidator<UpdateContactCategoryDto>
    {
        public ContactCategoryUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 255)
                .WithMessage(MessageResources.ItemNotLessThan3_NotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.Description).MaximumLength(1023).When(o => o.Description != null)
                .WithMessage(MessageResources.ItemNotMoreThan1023);
            
            RuleFor(x => x.Css).NotEmpty().MaximumLength(1023)
                .WithMessage(MessageResources.ItemNotMoreThan1023)
                .WithMessage(MessageResources.ItemNotNull);
        }
    }
}
