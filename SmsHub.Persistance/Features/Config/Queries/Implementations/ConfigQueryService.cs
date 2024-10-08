using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class ConfigQueryService: IConfigQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Config> _configs;
        public ConfigQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _uow.NotNull(nameof(_uow));

            _configs=_uow.Set<Entities.Config>();
            _configs.NotNull(nameof(_configs));
        }
        public async Task<ICollection<Entities.Config>> Get()
        {
            return await _configs.ToListAsync();
        }
        public async Task<Entities.Config> Get(int id)
        {
            return await _uow.FindOrThrowAsync<Entities.Config>(id);
        }

    }
}
