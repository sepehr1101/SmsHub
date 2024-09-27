using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class CcSendQueryService: ICcSendQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.CcSend> _ccSends;
        public CcSendQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _ccSends=_uow.Set<Entities.CcSend>();
        }
        public async Task<ICollection<Entities.CcSend>> Get()
        {
            var entities = await _ccSends.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.CcSend));
            return entities;
        }
        public async Task<Entities.CcSend> Get(int id)
        {
            var entity=await _ccSends.FindAsync(id);
            entity.NotNull(nameof(Entities.CcSend));
            return entity;
        }
    }
}
