using FluentValidation;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Contact.Validations
{
    internal class ContactNumberCategoryCreateValidator:AbstractValidator<CreateContactNumberCategoryDto>
    {
        public ContactNumberCategoryCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
            RuleFor(x=>x.Css).NotEmpty().MaximumLength(1023);
        }
    }
}
