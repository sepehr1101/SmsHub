using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Validations
{
    internal class ConsumerUpdateValidator:AbstractValidator<UpdateConsumerDto>
    {
        public ConsumerUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 255)
                .WithMessage(MessageResources.ItemNotLessThan3_NotMoreThan255)    
                .WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.Description).MaximumLength(1023).When(o => o.Description != null)
                .WithMessage(MessageResources.ItemNotMoreThan1023);

            RuleFor(x => x.ApiKey).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}
