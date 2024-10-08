using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Commands.Contracts;

namespace SmsHub.Persistence.Features.Line.Commands.Implementations
{
    public class LineCommandService: ILineCommandService
    {
        private readonly IUnitOfWork _uow;
       private readonly DbSet<Entities.Line> _lines;
        public LineCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _lines = _uow.Set<Entities.Line>();
        }
        public async Task Add(Entities.Line line)
        {
            await _lines.AddAsync(line);
        }
        public async Task Add(ICollection<Entities.Line> lines)
        {
            await _lines.AddRangeAsync(lines);
        }
        public void Delete(Entities.Line line)
        {
            _lines.Remove(line);
        }

    }
}
