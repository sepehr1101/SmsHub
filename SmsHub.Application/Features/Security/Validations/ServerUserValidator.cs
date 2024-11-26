using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Security.Validations
{
    public class ServerUserValidator: AbstractValidator<CreateServerUserDto>
    {
        public ServerUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MaximumLength(255)
                .WithMessage(MessageResources.ItemNotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);
        
            RuleFor(x => x.ApiKeyHash).NotEmpty().MaximumLength(128).Must(ValidationAnsiString.ValidateAnsi)
                .WithMessage(MessageResources.ItemNotMoreThan128)
                .WithMessage(MessageResources.ItemNotNull);
        }
    }
}
