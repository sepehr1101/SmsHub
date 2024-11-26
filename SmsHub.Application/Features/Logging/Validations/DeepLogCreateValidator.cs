using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Validations
{
    public class DeepLogCreateValidator : AbstractValidator<CreateDeepLogDto>
    {
        public DeepLogCreateValidator()
        {
            RuleFor(x => x.PrimaryDb)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x => x.PrimaryTable)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x => x.PrimaryId)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(63).WithMessage(MessageResources.ItemNotMoreThan63);

            RuleFor(x => x.Ip)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(64).WithMessage(MessageResources.ItemNotNull)
                .Must(ValidationAnsiString.ValidateAnsi).When(o => o.Ip != null);

            RuleFor(x => x.ClientInfo).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}