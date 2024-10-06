using FluentValidation;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Consumer.Validations
{
    internal class ConsumerValidatior:AbstractValidator<CreateConsumerDto>
    {
        public ConsumerValidatior()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 255);
        }
    }
}
