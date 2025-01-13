using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Receiving.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Receiving.Commands.Contracts;

namespace SmsHub.Persistence.Features.Receiving.Commands.Implementations
{
    public class ReceiveCommandService : IReceiveCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Receive> _receives;
        public ReceiveCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _receives = _uow.Set<Receive>();
        }
        public async Task Add(Receive receive)
        {
            await _receives.AddAsync(receive);
        }

        public async Task Add(ICollection<Receive> receive)
        {
            await _receives.AddRangeAsync(receive);
        }
    }
}
