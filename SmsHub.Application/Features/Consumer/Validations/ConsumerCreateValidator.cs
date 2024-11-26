using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Consumer.Validations
{
    public class ConsumerCreateValidator : AbstractValidator<CreateConsumerDto>
    {
        public ConsumerCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .Length(3, 255)  .WithMessage(MessageResources.ItemNotLessThan3_NotMoreThan255);

            RuleFor(x => x.Description).MaximumLength(1023).When(o => o.Description != null)
                .WithMessage(MessageResources.ItemNotMoreThan1023);

            RuleFor(x => x.ApiKey).NotEmpty().WithMessage(MessageResources.ItemNotNull);
        }
    }
}
