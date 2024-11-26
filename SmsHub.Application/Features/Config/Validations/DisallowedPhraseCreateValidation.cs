using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Validations
{
    public class DisallowedPhraseCreateValidation:AbstractValidator<CreateDisallowedPhraseDto>
    {
        public DisallowedPhraseCreateValidation()
        {
            RuleFor(x => x.Phrase).NotEmpty().Length(3, 255)
                .WithMessage(MessageResources.ItemNotLessThan3_NotMoreThan255)
                .WithMessage(MessageResources.ItemNotNull);
        }
    }
}
