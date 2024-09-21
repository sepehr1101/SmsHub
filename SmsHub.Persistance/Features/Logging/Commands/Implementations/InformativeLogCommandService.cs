using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;

namespace SmsHub.Persistence.Features.Logging.Commands.Implementations
{
    public class InformativeLogCommandService: IInformativeLogCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.InformativeLog> _informativeLogs;
        public InformativeLogCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _informativeLogs=_uow.Set<Entities.InformativeLog>();
        }
        public async Task Add(Entities.InformativeLog informativeLog)
        {
            await _informativeLogs.AddAsync(informativeLog);
        }
        public async Task Add(ICollection<Entities.InformativeLog> informativeLogs)
        {
            await _informativeLogs.AddRangeAsync(informativeLogs);
        }
    }
}
