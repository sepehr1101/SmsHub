using FluentValidation;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Validations
{
    internal class MessageStateCreateValidator : AbstractValidator<CreateMessageStateDto>
    {
    }
}
