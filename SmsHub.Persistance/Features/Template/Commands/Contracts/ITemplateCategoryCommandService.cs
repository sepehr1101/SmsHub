using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Template.Commands.Contracts
{
    public interface ITemplateCategoryCommandService
    {
        Task Add(TemplateCategory templateCategory);
        Task Add(ICollection<TemplateCategory> templateCategories);
        void Delete(TemplateCategory templateCategory);
    }
}
