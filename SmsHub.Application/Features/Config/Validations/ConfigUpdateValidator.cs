using FluentValidation;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Validations
{
    public class ConfigUpdateValidator:AbstractValidator<UpdateConfigDto>
    {
    }
}
