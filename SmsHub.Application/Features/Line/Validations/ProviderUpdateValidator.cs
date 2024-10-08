using FluentValidation;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Line.Validations
{
    internal class ProviderUpdateValidator:AbstractValidator<UpdateProviderDto>
    {
    }
}
