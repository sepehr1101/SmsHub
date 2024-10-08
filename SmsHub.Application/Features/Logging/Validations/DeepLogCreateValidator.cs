using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Validations
{
    internal class DeepLogCreateValidator : AbstractValidator<CreateDeepLogDto>
    {
        public DeepLogCreateValidator()
        {
            RuleFor(x => x.PrimaryDb).NotEmpty().MaximumLength(255);
            RuleFor(x => x.PrimaryTable).NotEmpty().MaximumLength(255);
            RuleFor(x => x.PrimaryId).NotEmpty().MaximumLength(63);
            RuleFor(x => x.Ip).Must(ValidationAnsiString.Execute).When(o => o.Ip != null);
            RuleFor(x => x.ClientInfo).NotEmpty();
        }
    }
}