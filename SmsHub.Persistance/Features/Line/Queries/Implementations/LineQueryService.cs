using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Line.Queries.Implementations
{
    public class LineQueryService: ILineQueryService
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
        public async Task<Entities.Line> Get(ProviderEnum id)
        {
            return await _uow.FindOrThrowAsync<Entities.Line>(id);    
        }
    }
}
