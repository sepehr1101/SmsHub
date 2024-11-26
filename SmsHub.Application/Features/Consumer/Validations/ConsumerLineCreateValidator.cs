using FluentValidation;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Consumer.Validations
{
    public class ConsumerLineCreateValidator:AbstractValidator<CreateConsumerLineDto>
    {
    }
}
