using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Validations
{
    public class PermittedTimeCreateValidator:AbstractValidator<CreatePermittedTimeDto>
    {
        public PermittedTimeCreateValidator()
        {
            RuleFor(x => x.FromTime).NotEmpty().Length(5) 
                .Must(ValidationAnsiString.ValidateAnsi)
                .Must( ValidationAnsiString.CheckTime)
                .WithMessage(MessageResources.ItemNotMoreThan5)
                .WithMessage(MessageResources.ItemNotNull);

            RuleFor(x=>x.ToTime ).NotEmpty().Length(5)
                .Must(ValidationAnsiString.ValidateAnsi)
                .Must(ValidationAnsiString.CheckTime)
                .WithMessage(MessageResources.ItemNotMoreThan5)
                .WithMessage(MessageResources.ItemNotNull);
        }
    }
}
