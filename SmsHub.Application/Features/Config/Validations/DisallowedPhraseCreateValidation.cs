using FluentValidation;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Validations
{
    internal class DisallowedPhraseCreateValidation:AbstractValidator<CreateDisallowedPhraseDto>
    {
        public DisallowedPhraseCreateValidation()
        {
            RuleFor(x => x.Phrase).NotEmpty().Length(3, 255);
        }
    }
}
