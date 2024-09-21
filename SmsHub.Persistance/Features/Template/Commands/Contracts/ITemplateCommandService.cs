namespace SmsHub.Persistence.Features.Template.Commands.Contracts
{
    public interface ITemplateCommandService
    {
        Task Add(Domain.Features.Entities.Template template);
        Task Add(ICollection<Domain.Features.Entities.Template> templates);
    }
}
