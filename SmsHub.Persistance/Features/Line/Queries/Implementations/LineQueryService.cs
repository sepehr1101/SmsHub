using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Line.Queries.Implementations
{
    public class LineQueryService : ILineQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Line> _lines;
        public LineQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _lines = _uow.Set<Entities.Line>();
            _lines.NotNull(nameof(_lines));
        }
        public async Task<ICollection<Entities.Line>> Get()
        {
            return await _lines.ToListAsync();
        }
        public async Task<Entities.Line> Get(int id)
        {
            return await
                _uow
                .FindOrThrowAsync<Entities.Line>(id);
        }
        public async Task<Entities.Line> GetIncludeProvider(int id)
        {
            var line= await _lines
                    .Include(x => x.Provider)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
            return line;
            //return await _lines
            //        .Include(x => x.Provider)
            //        .Where(x => x.Id == id)
            //        .FirstOrDefaultAsync();

        }
    }
}
