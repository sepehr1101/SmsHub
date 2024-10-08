using FluentValidation;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Validations
{
    internal class ConsumerSafaIpCreateValidator:AbstractValidator<UpdateConsumerSafeIpDto>
    {
        public ConsumerSafaIpCreateValidator()
        {
            RuleFor(x => x.FromIp).NotEmpty().MaximumLength(64);
            RuleFor(x=>x.ToIp).NotEmpty().MaximumLength(64);
        }
    }
}
