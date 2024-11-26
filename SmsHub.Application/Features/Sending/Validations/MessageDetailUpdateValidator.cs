using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Validations
{
    public class MessageDetailUpdateValidator : AbstractValidator<UpdateMessageDetailDto>
    {
        public MessageDetailUpdateValidator()
        {
            RuleFor(x => x.Receptor)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(15).WithMessage(MessageResources.ItemNotMoreThan15);

            RuleFor(x => x.Text).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}
