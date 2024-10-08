using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Template.Commands.Contracts;

namespace SmsHub.Persistence.Features.Template.Commands.Implementations
{
    public class TemplateCommandService: ITemplateCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Template> _templates;
        public TemplateCommandService(IUnitOfWork uow)
        {
             _uow=uow;
            _templates=_uow.Set<Entities.Template>();
        }
        public async Task Add(Entities.Template template)
        {
            await _templates.AddAsync(template);
        }
        public async Task Add(ICollection<Entities.Template> templates)
        {
            await _templates.AddRangeAsync(templates);
        }
        public void Delete(Entities.Template template)
        {
            _templates.Remove(template);
        }
    }
}
