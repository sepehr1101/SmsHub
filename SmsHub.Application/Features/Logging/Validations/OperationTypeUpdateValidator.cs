using FluentValidation;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Validations
{
    public class OperationTypeUpdateValidator:AbstractValidator<UpdateOperationTypeDto>
    {
        public OperationTypeUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Css).NotEmpty().MaximumLength(1023);
        }
    }
}
