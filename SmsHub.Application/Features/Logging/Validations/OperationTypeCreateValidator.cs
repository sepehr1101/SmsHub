using FluentValidation;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Validations
{
    internal class OperationTypeCreateValidator:AbstractValidator<CreateOperationTypeDto>
    {
        public OperationTypeCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Css).NotEmpty().MaximumLength(1023);
        }
    }
}
