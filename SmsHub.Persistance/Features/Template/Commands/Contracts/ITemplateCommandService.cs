using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Template.Commands.Contracts
{
    public interface ITemplateCommandService
    {
        Task Add(Entities.Template template);
        Task Add(ICollection<Entities.Template> templates);
        void Delete(Entities.Template template);
    }
}
