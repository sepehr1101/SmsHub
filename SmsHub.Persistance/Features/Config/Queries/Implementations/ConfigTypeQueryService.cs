using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class ConfigTypeQueryService: IConfigTypeQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ConfigType> _configTypes;
        public ConfigTypeQueryService(IUnitOfWork uow)
        {
            _uow=uow; 
            _configTypes=_uow.Set<Entities.ConfigType>();
        }
        public async Task<ICollection<Entities.ConfigType>> Get()
        {
            var entities = await _configTypes.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.ConfigType));
            return entities;
        }
        public async Task<Entities.ConfigType> Get(int id)
        {
            var entity=await _configTypes.FindAsync(id);
            entity.NotNull(nameof(Entities. ConfigType));
            return entity;
        }
    }
}
