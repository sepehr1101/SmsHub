using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Validations
{
    public class DeepLogUpdateValidator : AbstractValidator<UpdateDeepLogDto>
    {
        public DeepLogUpdateValidator()
        {
            RuleFor(x => x.PrimaryDb).NotEmpty().MaximumLength(255);
            RuleFor(x => x.PrimaryTable).NotEmpty().MaximumLength(255);
            RuleFor(x => x.PrimaryId).NotEmpty().MaximumLength(63);
            RuleFor(x => x.Ip).Must(ValidationAnsiString.ValidateAnsi).When(o => o.Ip != null);
            RuleFor(x => x.ClientInfo).NotEmpty();
        }
    }
}
