using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Validations
{
    public class LogLevelUpdateValidator:AbstractValidator<UpdateLogLevelDto>
    {
        public LogLevelUpdateValidator()
        {
            RuleFor(x => x.Css)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(1023).WithMessage(MessageResources.ItemNotMoreThan255);
        }
    }
}
