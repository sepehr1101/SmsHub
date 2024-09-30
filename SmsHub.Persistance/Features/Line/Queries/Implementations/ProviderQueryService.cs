using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Persistence.Features.Line.Queries.Implementations
{
    public class ProviderQueryService : IProviderQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Provider> _providers;
        public ProviderQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _providers = _uow.Set<Provider>();
            _providers.NotNull(nameof(_providers));
        }
        public async Task<Provider> Get(ProviderEnum id)
        {           
            return await _uow.FindOrThrowAsync<Provider>(id);
        }
        public async Task<ICollection<Provider>> Get()
        {
            return await _providers.ToListAsync();
        }
    }
}