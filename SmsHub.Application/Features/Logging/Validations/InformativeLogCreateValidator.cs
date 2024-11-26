using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Validations
{
    public class InformativeLogCreateValidator:AbstractValidator<CreateInformativeLogDto>
    {
        public InformativeLogCreateValidator()
        {
            RuleFor(x => x.Section)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x=>x.Description).MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x=>x.UserInfo).MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x=>x.Ip)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(64).WithMessage(MessageResources.ItemNotMoreThan64)
                .Must(ValidationAnsiString.ValidateAnsi);//todo: ansi check 64

            RuleFor(x => x.ClientInfo).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}