using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Contracts;

namespace SmsHub.Persistence.Features.Config.Commands.Implementations
{
    public class CcSendCommandService : ICcSendCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<CcSend> _ccSends;
        public CcSendCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _ccSends = _uow.Set<CcSend>();
        }

        public async Task Add(CcSend ccSend)
        {
            await _ccSends.AddAsync(ccSend);
        }
        public async Task Add(ICollection<CcSend> ccSends)
        {
            await _ccSends.AddRangeAsync(ccSends);
        }

        public void Delete(CcSend ccSend)
        {
            _ccSends.Remove(ccSend);
        }
    }
}
