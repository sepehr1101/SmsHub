using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Receiving.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Receiving.Commands.Contracts;

namespace SmsHub.Persistence.Features.Receiving.Commands.Implementations
{
    public class ReceiveCommandService : IReceiveCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Received> _receives;
        public ReceiveCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _receives = _uow.Set<Received>();
        }
        public async Task<Received> Add(Received receive)
        {
            await _receives.AddAsync(receive);
            return receive;
        }

        public async Task<ICollection<Received>> Add(ICollection<Received> receive)
        {
            await _receives.AddRangeAsync(receive);
            return receive;
        }
    }
}
