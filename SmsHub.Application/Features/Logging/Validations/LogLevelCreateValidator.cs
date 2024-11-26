using FluentValidation;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Validations
{
    public class LogLevelCreateValidator:AbstractValidator<CreateLogLevelDto>
    {
        public LogLevelCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
            RuleFor(x=>x.Css).NotEmpty().MaximumLength(1023);
        }
    }
}
