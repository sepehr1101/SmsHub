using FluentValidation;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Validations
{
    public class MessageBatchCreateValidator:AbstractValidator<CreateMessageBatchDto>
    {
    }
}
