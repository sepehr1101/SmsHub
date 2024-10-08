using FluentValidation;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Validations
{
    internal class ConfigCreateValidator:AbstractValidator<CreateConfigDto>
    {
        public ConfigCreateValidator()
        {
            RuleFor(x=>x.ConfigTypeGroupId).NotEmpty();
           RuleFor(x=>x.TemplateId).NotEmpty();
        }
    }
}
