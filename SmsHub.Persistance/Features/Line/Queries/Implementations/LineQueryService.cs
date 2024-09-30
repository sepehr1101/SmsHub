using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Line.Queries.Implementations
{
    public class LineQueryService: ILineQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Line> _lines;
        public LineQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _lines = _uow.Set<Entities.Line>();
        }
        public async Task<ICollection<Entities.Line>> Get()
        {
            var entities = await _lines.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.Line));
            return entities;
        }
        public async Task<Entities.Line> Get(int id)
        {
            var entity = await _lines.FindAsync(id);
            entity.NotNull(nameof(Entities.Line));
            return entity;
        }

    }
}
