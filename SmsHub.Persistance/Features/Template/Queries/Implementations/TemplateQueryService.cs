using Entities = SmsHub.Domain.Features.Entities;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Template.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Template.Queries.Implementations
{
    public class TemplateQueryService: ITemplateQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Template> _templates;
        public TemplateQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _templates = _uow.Set<Entities.Template>();
            _templates.NotNull(nameof(_templates));
        }
        public async Task<ICollection<Entities.Template>> Get()
        {
            return await _templates.ToListAsync();
        }
        public async Task<Entities.Template> Get(ProviderEnum id)
        {
            return await _uow.FindOrThrowAsync<Entities.Template>(id);
        }
    }
}
