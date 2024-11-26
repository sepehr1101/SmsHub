using FluentValidation;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Template.Validations
{
    public class TemplateCategoryUpdateValidator : AbstractValidator<UpdateTemplateCategoryDto>
    {
        public TemplateCategoryUpdateValidator()
        {
            
        }
    }
}
