using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Validations
{
    public class ConfigTypeCreateValidator:AbstractValidator<CreateConfigTypeDto>
    {
        public ConfigTypeCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 255)
                .WithMessage(MessageResources.ItemNotLessThan3_NotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);

            RuleFor(x => x.Description).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}
