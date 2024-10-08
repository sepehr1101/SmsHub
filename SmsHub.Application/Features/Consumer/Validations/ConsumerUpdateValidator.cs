using FluentValidation;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Validations
{
    internal class ConsumerUpdateValidator:AbstractValidator<UpdateConsumerDto>
    {
        public ConsumerUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 255);
            RuleFor(x => x.Description).MaximumLength(1023).When(o => o.Description != null);
            RuleFor(x => x.ApiKey).NotEmpty();
        }
    }
}
