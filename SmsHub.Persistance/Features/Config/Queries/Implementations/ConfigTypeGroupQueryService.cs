using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class ConfigTypeGroupQueryService: IConfigTypeGroupQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ConfigTypeGroup> _configTypeGroups;
        public ConfigTypeGroupQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _uow.NotNull(nameof(_uow));

            _configTypeGroups=_uow.Set<ConfigTypeGroup>();
            _configTypeGroups.NotNull(nameof(_configTypeGroups));
        }
        public async Task<ICollection<ConfigTypeGroup>> Get()
        {
            return await _configTypeGroups.ToListAsync();
        }
        public async Task<ConfigTypeGroup> Get(int id)
        {
            return await _uow.FindOrThrowAsync<ConfigTypeGroup>(id);
        }
    }
}
