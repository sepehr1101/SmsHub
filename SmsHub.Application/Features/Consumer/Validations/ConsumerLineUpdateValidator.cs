using FluentValidation;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Validations
{
    internal class ConsumerLineUpdateValidator:AbstractValidator<UpdateConsumerLineDto>
    {
    }
}
