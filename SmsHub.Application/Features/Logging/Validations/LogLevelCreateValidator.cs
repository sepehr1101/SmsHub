using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Validations
{
    public class LogLevelCreateValidator:AbstractValidator<CreateLogLevelDto>
    {
        public LogLevelCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x=>x.Css)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(1023).WithMessage(MessageResources.ItemNotMoreThan255);
        }
    }
}
