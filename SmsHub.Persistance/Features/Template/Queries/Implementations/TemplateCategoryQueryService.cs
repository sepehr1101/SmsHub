using Entities = SmsHub.Domain.Features.Entities;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Template.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Template.Queries.Implementations
{
    public class TemplateCategoryQueryService: ITemplateCategoryQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.TemplateCategory> _templateCategories;
        public TemplateCategoryQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _templateCategories = _uow.Set<Entities.TemplateCategory>();
        }
        public async Task<ICollection<Entities.TemplateCategory>> Get()
        {
            var entities = await _templateCategories.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.TemplateCategory));
            return entities;
        }
        public async Task<Entities.TemplateCategory> Get(int id)
        {
            var entity = await _templateCategories.FindAsync(id);
            entity.NotNull(nameof(Entities.TemplateCategory));
            return entity;
        }
    }
}
