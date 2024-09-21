using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Create.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Create.Implementations
{
    public class ConfigTypeCommandService: IConfigTypeCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ConfigType> _configTypes;
        public ConfigTypeCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _configTypes = _uow.Set<Entities.ConfigType>();
        }

        public async Task Add(Entities.ConfigType config)
        {
            await _configTypes.AddAsync(config);
        }
        public async Task Add(ICollection<Entities.ConfigType> configTypes)
        {
            await _configTypes.AddRangeAsync(configTypes);
        }
    }
}
