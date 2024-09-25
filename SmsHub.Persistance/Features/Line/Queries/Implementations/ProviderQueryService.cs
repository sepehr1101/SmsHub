using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Line.Queries.Implementations
{
    public class ProviderQueryService: IProviderQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Provider> _providers;
        public ProviderQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _providers = _uow.Set<Entities.Provider>();
        }
        public async Task<ICollection<Entities.Provider>> Get()
        {
            var entities = await _providers.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.Provider));
            return entities;
        }
        public async Task<Entities.Provider> Get(int id)
        {
            var entity = await _providers.FindAsync(id);
            entity.NotNull(nameof(Entities.Provider));
            return entity;
        }
    }
}
