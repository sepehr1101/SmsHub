using FluentValidation;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Validations
{
    internal class MessageDetailUpdateValidator : AbstractValidator<UpdateMessageDetailDto>
    {
        public MessageDetailUpdateValidator()
        {
            RuleFor(x => x.Receptor).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Text).NotEmpty();
        }
    }
}
