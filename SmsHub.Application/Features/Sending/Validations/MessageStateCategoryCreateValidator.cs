using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Validations
{
    public class MessageStateCategoryCreateValidator : AbstractValidator<CreateMessageStateCategoryDto>
    {
        public MessageStateCategoryCreateValidator()
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
