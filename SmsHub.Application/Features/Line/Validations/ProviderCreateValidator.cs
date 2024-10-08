using FluentValidation;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Line.Validations
{
    internal class ProviderCreateValidator:AbstractValidator<CreateProviderDto>
    {
        public ProviderCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);// unique
            RuleFor(x => x.Website).MaximumLength(255);
            RuleFor(x=>x.BaseUri).NotEmpty().MaximumLength(255);
            RuleFor(x=>x.FallbackBaseUri).MaximumLength(255);
            RuleFor(x => x.DefaultPreNumber).MaximumLength(15);
        }
    }
}