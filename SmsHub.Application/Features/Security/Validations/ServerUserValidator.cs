using FluentValidation;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Security.Validations
{
    internal class ServerUserValidator: AbstractValidator<CreateServerUserDto>
    {
        public ServerUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
