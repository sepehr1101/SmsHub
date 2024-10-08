using FluentValidation;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Validations
{
    internal class TemplateCategoryUpdateValidator : AbstractValidator<UpdateTemplateCategoryDto>
    {
    }
}
