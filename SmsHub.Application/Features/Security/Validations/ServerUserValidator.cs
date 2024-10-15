using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Security.Validations
{
    internal class ServerUserValidator: AbstractValidator<CreateServerUserDto>
    {
        public ServerUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MaximumLength(255);
            RuleFor(x => x.ApiKeyHash).NotEmpty().MaximumLength(128).Must(ValidationAnsiString.ValidateAnsi);
        }
    }
}
