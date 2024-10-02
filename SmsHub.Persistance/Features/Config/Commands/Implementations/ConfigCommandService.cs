using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Implementations
{
    public class ConfigCommandService : IConfigCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Config> _configs;
        public ConfigCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _configs = _uow.Set<Entities.Config>();
        }

        public async Task Add(Entities.Config config)
        {
            await _configs.AddAsync(config);
        }
        public async Task Add(ICollection<Entities.Config> configs)
        {
            await _configs.AddRangeAsync(configs);
        }
        public void Delete(Entities.Config config)
        {
            _configs.Remove(config);
        }
    }
}