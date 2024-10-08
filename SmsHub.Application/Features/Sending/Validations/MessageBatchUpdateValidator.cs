using FluentValidation;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Validations
{
    internal class MessageBatchUpdateValidator : AbstractValidator<UpdateMessageBatchDto>
    {
    }
}
