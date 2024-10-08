using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Contracts;

namespace SmsHub.Persistence.Features.Config.Commands.Implementations
{
    public class ConfigTypeGroupCommandService : IConfigTypeGroupCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ConfigTypeGroup> _configTypeGroups;
        public ConfigTypeGroupCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _configTypeGroups = _uow.Set<ConfigTypeGroup>();
        }

        public async Task Add(ConfigTypeGroup configTypeGroup)
        {
            await _configTypeGroups.AddAsync(configTypeGroup);
        }
        public async Task Add(ICollection<ConfigTypeGroup> configTypeGroup)
        {
            await _configTypeGroups.AddRangeAsync(configTypeGroup);
        }
        public void Delete(ConfigTypeGroup configType)
        {
            _configTypeGroups.Remove(configType);
        }
    }
}
