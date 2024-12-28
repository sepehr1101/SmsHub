using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class ConfigTypeQueryService: IConfigTypeQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ConfigType> _configTypes;
        public ConfigTypeQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _uow.NotNull(nameof(_uow));

            _configTypes=_uow.Set<ConfigType>();
            _configTypes.NotNull(nameof(_configTypes));
        }
        public async Task<ICollection<ConfigType>> Get()
        {
           return await _configTypes.ToListAsync();
        }
        public async Task<ConfigType> Get(short id)
        {
            return await _uow.FindOrThrowAsync<ConfigType>(id);
        }
    }
}
