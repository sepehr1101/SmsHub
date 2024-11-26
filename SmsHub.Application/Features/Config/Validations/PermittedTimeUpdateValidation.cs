using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Validations
{
    public class PermittedTimeUpdateValidation : AbstractValidator<UpdatePermittedTimeDto>
    {
        public PermittedTimeUpdateValidation()
        {
            RuleFor(x => x.FromTime)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .Length(5).WithMessage(MessageResources.ItemNotMoreThan5)
                .Must(ValidationAnsiString.ValidateAnsi)
                .Must(ValidationAnsiString.CheckTime);

            RuleFor(x => x.ToTime)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .Length(5).WithMessage(MessageResources.ItemNotMoreThan5)
                .Must(ValidationAnsiString.ValidateAnsi)
                .Must(ValidationAnsiString.CheckTime);
        }
    }
}
