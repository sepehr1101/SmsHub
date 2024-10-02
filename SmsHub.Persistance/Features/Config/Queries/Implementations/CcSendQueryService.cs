using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class CcSendQueryService: ICcSendQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<CcSend> _ccSends;
        public CcSendQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _uow.NotNull(nameof(_uow));

            _ccSends=_uow.Set<CcSend>();
            _ccSends.NotNull(nameof(_ccSends));
        }
        public async Task<ICollection<CcSend>> Get()
        {
            return await _ccSends.ToListAsync();
        }
        public async Task<CcSend> Get(int id)
        {
            return await _uow.FindOrThrowAsync<CcSend>(id);
         
        }
    }
}
