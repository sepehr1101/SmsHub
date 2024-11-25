using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Validations
{
    internal class CcSendUpdateValidator:AbstractValidator<UpdateCcSendDto>
    {
        public CcSendUpdateValidator()
        {
            RuleFor(x => x.Mobile).NotEmpty().Length(11).WithMessage(MessageResources.ItemNotMoreThan11)
                .Must(ValidationAnsiString.CheckPersianPhoneNumber);
        }
    }
}
