using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class ProviderDeliveryStatusQueryService : IProviderDeliveryStatusQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ProviderDeliveryStatus> _providerDeliveryStatus;
        public ProviderDeliveryStatusQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _uow.NotNull(nameof(_uow));

            _providerDeliveryStatus=_uow.Set<ProviderDeliveryStatus>();
            _providerDeliveryStatus.NotNull(nameof(_providerDeliveryStatus));
        }

        public async Task<ProviderDeliveryStatus> Get(int id)
        {
            return await _uow.FindOrThrowAsync<ProviderDeliveryStatus>(id);
        }

        public async Task<ICollection<ProviderDeliveryStatus>> Get()
        {
            return await _providerDeliveryStatus.ToListAsync();
        }
    }
}
