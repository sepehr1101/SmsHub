namespace SmsHub.Persistence.Features.Template.Queries.Contracts
{
    public interface ITemplateQueryService
    {
        Task<ICollection<Domain.Features.Entities.Template>> Get();
        Task<Domain.Features.Entities.Template> Get(int id);
    }
}
