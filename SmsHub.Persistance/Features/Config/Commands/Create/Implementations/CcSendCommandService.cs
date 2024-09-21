using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Create.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Create.Implementations
{
    public class CcSendCommandService: ICcSendCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.CcSend> _ccSends;
        public CcSendCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _ccSends = _uow.Set<Entities.CcSend>();
        }

        public async Task Add(Entities.CcSend ccSend)
        {
            await _ccSends.AddAsync(ccSend);
        }
        public async Task Add(ICollection<Entities.CcSend> ccSends)
        {
            await _ccSends.AddRangeAsync(ccSends);
        }
    }
}
