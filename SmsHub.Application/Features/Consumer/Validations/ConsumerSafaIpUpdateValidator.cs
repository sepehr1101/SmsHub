using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Validations
{
    public class ConsumerSafaIpUpdateValidator:AbstractValidator<UpdateConsumerSafeIpDto>
    {
        public ConsumerSafaIpUpdateValidator()
        {
            RuleFor(x => x.FromIp).NotEmpty().MaximumLength(64)
                .WithMessage(MessageResources.ItemNotMoreThan64)
                .WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.ToIp).NotEmpty().MaximumLength(64)
                .WithMessage(MessageResources.ItemNotMoreThan64)
                .WithMessage(MessageResources.ItemNotNull);
        }
    }
}
