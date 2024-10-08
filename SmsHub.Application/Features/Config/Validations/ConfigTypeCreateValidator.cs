using FluentValidation;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Validations
{
    internal class ConfigTypeCreateValidator:AbstractValidator<CreateConfigTypeDto>
    {
        public ConfigTypeCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 255);
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
