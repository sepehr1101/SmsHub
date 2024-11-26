using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Validations
{
    public class InformativeLogCreateValidator:AbstractValidator<CreateInformativeLogDto>
    {
        public InformativeLogCreateValidator()
        {
            RuleFor(x => x.Section).NotEmpty().MaximumLength(255);
            RuleFor(x=>x.Description).MaximumLength(255);
            RuleFor(x=>x.UserInfo).MaximumLength(255);
            RuleFor(x=>x.Ip).NotEmpty().MaximumLength(64).Must(ValidationAnsiString.ValidateAnsi);
            RuleFor(x => x.ClientInfo).NotEmpty();
        }
    }
}