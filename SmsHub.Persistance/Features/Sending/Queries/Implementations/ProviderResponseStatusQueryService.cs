using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class ProviderResponseStatusQueryService : IProviderResponseStatusQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ProviderResponseStatus> _providerResponseStatus;
        public ProviderResponseStatusQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _providerResponseStatus = _uow.Set<ProviderResponseStatus>();
            _providerResponseStatus.NotNull(nameof(_providerResponseStatus));
        }

        public async Task<ICollection<ProviderResponseStatus>> Get()
        {
            var s = await _providerResponseStatus.ToListAsync();
            return s;
            //return await _providerResponseStatus.ToListAsync();
        }
        
        
        public async Task<ProviderResponseStatus> Get(int id)
        {
            var list = _providerResponseStatus.ToList();
            return await _uow.FindOrThrowAsync<ProviderResponseStatus>(id);
        }
    }
}
