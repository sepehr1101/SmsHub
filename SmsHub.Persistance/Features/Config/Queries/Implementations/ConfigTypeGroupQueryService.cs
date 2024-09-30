using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class ConfigTypeGroupQueryService: IConfigTypeGroupQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ConfigTypeGroup> _configTypeGroups;
        public ConfigTypeGroupQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _configTypeGroups=_uow.Set<Entities.ConfigTypeGroup>();
        }
        public async Task<ICollection<Entities.ConfigTypeGroup>> Get()
        {
            var entities = await _configTypeGroups.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.ConfigTypeGroup));
            return entities;
        }
        public async Task<Entities.ConfigTypeGroup> Get(int id)
        {
            var entity=await _configTypeGroups.FindAsync(id);
            entity.NotNull(nameof(Entities.ConfigTypeGroup));
            return entity;
        }
    }
}
