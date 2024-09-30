using SmsHub.Persistence.Features.Logging.Queries.Contracts;
using Entities = SmsHub.Domain.Features.Entities;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Logging.Queries.Implementations
{
    public  class InformativeLogQueryService: IInformativeLogQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.InformativeLog> _informativeLogs;
        public InformativeLogQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _informativeLogs = _uow.Set<Entities.InformativeLog>();
        }
        public async Task<ICollection<Entities.InformativeLog>> Get()
        {
            var entities = await _informativeLogs.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.InformativeLog));
            return entities;
        }
        public async Task<Entities.InformativeLog> Get(int id)
        {
            var entity = await _informativeLogs.FindAsync(id);
            entity.NotNull(nameof(Entities.InformativeLog));
            return entity;
        }
    }
}
