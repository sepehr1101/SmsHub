using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Validations
{
    internal class PermittedTimeCreateValidator:AbstractValidator<CreatePermittedTimeDto>
    {
        public PermittedTimeCreateValidator()
        {
            RuleFor(x => x.FromTime).NotEmpty().Length(5).Must(ValidationAnsiString.Execute);
            RuleFor(x=>x.ToTime ).NotEmpty().Length(5).Must(ValidationAnsiString.Execute);
        }
    }
}
