using FluentValidation;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Validations
{
    internal class MessageDetailCreateValidator : AbstractValidator<CreateMessageDetailDto>
    {
        public MessageDetailCreateValidator()
        {
            RuleFor(x => x.Receptor).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Text).NotEmpty();
        }
    }
}