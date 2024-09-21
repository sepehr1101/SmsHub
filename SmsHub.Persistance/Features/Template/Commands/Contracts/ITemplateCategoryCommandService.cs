namespace SmsHub.Persistence.Features.Template.Commands.Contracts
{
    public interface ITemplateCategoryCommandService
    {
        Task Add(Domain.Features.Entities.TemplateCategory templateCategory);
        Task Add(ICollection<Domain.Features.Entities.TemplateCategory> templateCategories);
    }
}
