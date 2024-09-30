using SmsHub.Persistence.Features.Logging.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Logging.Queries.Implementations
{
    public  class InformativeLogQueryService: IInformativeLogQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<InformativeLog> _informativeLogs;
        public InformativeLogQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _informativeLogs = _uow.Set<InformativeLog>();
            _informativeLogs.NotNull(nameof(_informativeLogs));
        }
        public async Task<ICollection<InformativeLog>> Get()
        {
            return await _informativeLogs.ToListAsync(); 
        }
        public async Task<InformativeLog> Get(ProviderEnum id)
        {
            return await _uow.FindOrThrowAsync<InformativeLog>(id);
        }
    }
}
