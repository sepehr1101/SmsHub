using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Create.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Create.Implementations
{
    public class ConfigTypeGroupCommandService: IConfigTypeGroupCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ConfigTypeGroup> _configTypeGroups;
        public ConfigTypeGroupCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _configTypeGroups = _uow.Set<Entities.ConfigTypeGroup>();
        }

        public async Task Add(Entities.ConfigTypeGroup configTypeGroup)
        {
            await _configTypeGroups.AddAsync(configTypeGroup);
        }
        public async Task Add(ICollection<Entities.ConfigTypeGroup> configTypeGroup)
        {
            await _configTypeGroups.AddRangeAsync(configTypeGroup);
        }
    }
}
