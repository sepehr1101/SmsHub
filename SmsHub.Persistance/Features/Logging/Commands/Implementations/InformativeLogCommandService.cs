using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Commands.Implementations
{
    public class InformativeLogCommandService: IInformativeLogCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<InformativeLog> _informativeLogs;
        public InformativeLogCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _informativeLogs=_uow.Set<InformativeLog>();
        }
        public async Task Add(InformativeLog informativeLog)
        {
            await _informativeLogs.AddAsync(informativeLog);
        }
        public async Task Add(ICollection<InformativeLog> informativeLogs)
        {
            await _informativeLogs.AddRangeAsync(informativeLogs);
        }
        public void Delete(InformativeLog informativeLog)
        {
            _informativeLogs.Remove(informativeLog);
        }

    }
}
