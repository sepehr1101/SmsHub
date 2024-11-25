using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Validations
{
    internal class MessageStateCategoryUpdateValidator : AbstractValidator<UpdateMessageStateCategoryDto>
    {
        public MessageStateCategoryUpdateValidator()
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
