using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Contracts;

namespace SmsHub.Persistence.Features.Config.Commands.Implementations
{
    public class ConfigTypeCommandService : IConfigTypeCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ConfigType> _configTypes;
        public ConfigTypeCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _configTypes = _uow.Set<ConfigType>();
        }

        public async Task Add(ConfigType config)
        {
            await _configTypes.AddAsync(config);
        }
        public async Task Add(ICollection<ConfigType> configTypes)
        {
            await _configTypes.AddRangeAsync(configTypes);
        }
        public void Delete(ConfigType configType)
        {
            _configTypes.Remove(configType);
        }
    }
}
