using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Validations
{
    public class OperationTypeUpdateValidator:AbstractValidator<UpdateOperationTypeDto>
    {
        public OperationTypeUpdateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x => x.Css)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(1023).WithMessage(MessageResources.ItemNotMoreThan255);
        }
    }
}
