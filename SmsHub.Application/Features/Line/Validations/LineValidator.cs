using FluentValidation;
using FluentValidation.Validators;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Line.Validations
{
    internal class LineValidator: AbstractValidator<CreateLineDto>
    {
        public LineValidator()
        {
            RuleFor(x => x.Credential).NotEmpty();
            RuleFor(x=>x.ProviderId).IsInEnum();
            RuleFor(x=>x.Number).NotEmpty().Length(4,15)
                .Must(x => long.TryParse(x, out var val) && val > 0);
        }
      
    }
    public class ListCountValidator<T, TCollectionElement> : PropertyValidator<T, IList<TCollectionElement>>
    {
        private int _max;

        public ListCountValidator(int max)
        {
            _max = max;
        }

        public override bool IsValid(ValidationContext<T> context, IList<TCollectionElement> list)
        {
            if (list != null && list.Count >= _max)
            {
                context.MessageFormatter.AppendArgument("MaxElements", _max);
                return false;
            }

            return true;
        }

        public override string Name => "ListCountValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "{PropertyName} must contain fewer than {MaxElements} items.";
    }
    public static class MyValidatorExtensions
    {
        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {
            return ruleBuilder.SetValidator(new ListCountValidator<T, TElement>(num));
        }
    }
}
