using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class PermittedTimeQueryService: IPermittedTimeQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.PermittedTime> _permittedTimes;
        public PermittedTimeQueryService(IUnitOfWork uow)
        {
            _uow= uow;
            _permittedTimes=_uow.Set<Entities.PermittedTime>();
        }
        public async Task<ICollection<Entities.PermittedTime>> Get()
        {
            var entities = await _permittedTimes.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.PermittedTime));
            return entities;
        }
        public async Task<Entities.PermittedTime> Get(int id)
        {
            var entity=await _permittedTimes.FindAsync(id);
            entity.NotNull(nameof(Entities.PermittedTime));
            return entity;
        }
    }
}
