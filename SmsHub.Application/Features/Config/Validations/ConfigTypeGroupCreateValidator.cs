using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Validations
{
    public class ConfigTypeGroupCreateValidator:AbstractValidator<CreateConfigTypeGroupDto>
    {
        public ConfigTypeGroupCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .Length(3, 255).WithMessage(MessageResources.ItemNotLessThan3_NotMoreThan255);

            RuleFor(x => x.Description).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}
