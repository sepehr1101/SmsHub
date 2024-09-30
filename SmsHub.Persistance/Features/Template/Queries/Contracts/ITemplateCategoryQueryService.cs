namespace SmsHub.Persistence.Features.Template.Queries.Contracts
{
    public interface ITemplateCategoryQueryService
    {
        Task<ICollection<Domain.Features.Entities.TemplateCategory>> Get();
        Task<Domain.Features.Entities.TemplateCategory> Get(int id);
    }
}
