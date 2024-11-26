using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Security.Validations
{
    public class ServerUserValidator : AbstractValidator<CreateServerUserDto>
    {
        public ServerUserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x => x.ApiKeyHash)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(128).WithMessage(MessageResources.ItemNotMoreThan128)
                .Must(ValidationAnsiString.ValidateAnsi);

        }
    }
}
