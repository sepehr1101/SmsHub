using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Validations
{
    public class MessageDetailCreateValidator : AbstractValidator<CreateMessageDetailDto>
    {
        public MessageDetailCreateValidator()
        {
            RuleFor(x => x.Receptor)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(15).WithMessage(MessageResources.ItemNotMoreThan15);

            RuleFor(x => x.Text).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}