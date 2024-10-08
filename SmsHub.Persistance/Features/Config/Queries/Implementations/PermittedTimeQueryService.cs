using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class PermittedTimeQueryService: IPermittedTimeQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<PermittedTime> _permittedTimes;
        public PermittedTimeQueryService(IUnitOfWork uow)
        {
            _uow= uow;
            _uow.NotNull(nameof(_uow));

            _permittedTimes=_uow.Set<PermittedTime>();
            _permittedTimes.NotNull(nameof(_permittedTimes));
        }
        public async Task<ICollection<PermittedTime>> Get()
        {
            return await _permittedTimes.ToListAsync();
        }
        public async Task<PermittedTime> Get(int id)
        {
            return await _uow.FindOrThrowAsync<PermittedTime>(id);
        }
    }
}
