using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class ConfigQueryService: IConfigQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Config> _configs;
        public ConfigQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _configs=_uow.Set<Entities.Config>();
        }
        public async Task<ICollection<Entities.Config>> Get()
        {
            var entities = await _configs.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.Config));
            return entities;
        }
        public async Task<Entities.Config> Get(int id)
        {
            var entity=await _configs.FindAsync(id);
            entity.NotNull(nameof(Entities.Config));
            return entity;
        }

    }
}
