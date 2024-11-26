using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Line.Validations
{
    public class ProviderCreateValidator : AbstractValidator<CreateProviderDto>
    {
        public ProviderCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
               .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255)
                .WithMessage(MessageResources.ItemIsDuplicate);//IsUnique

            RuleFor(x => x.Website).MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x => x.BaseUri)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x => x.FallbackBaseUri).MaximumLength(255).WithMessage(MessageResources.ItemNotMoreThan255);

            RuleFor(x => x.DefaultPreNumber).MaximumLength(15).WithMessage(MessageResources.ItemNotMoreThan15);
        }
    }
}