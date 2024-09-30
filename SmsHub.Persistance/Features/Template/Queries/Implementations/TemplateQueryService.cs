using Entities = SmsHub.Domain.Features.Entities;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Template.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Template.Queries.Implementations
{
    public class TemplateQueryService: ITemplateQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Template> _templates;
        public TemplateQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _templates = _uow.Set<Entities.Template>();
        }
        public async Task<ICollection<Entities.Template>> Get()
        {
            var entities = await _templates.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.Template));
            return entities;
        }
        public async Task<Entities.Template> Get(int id)
        {
            var entity = await _templates.FindAsync(id);
            entity.NotNull(nameof(Entities.Template));
            return entity;
        }
    }
}
