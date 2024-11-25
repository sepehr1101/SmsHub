using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Validations
{
    internal class ConfigCreateValidator:AbstractValidator<CreateConfigDto>
    {
        public ConfigCreateValidator()
        {
            RuleFor(x => x.ConfigTypeGroupId).NotEmpty().WithMessage(MessageResources.ItemNotNull);
            RuleFor(x=>x.TemplateId).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}
