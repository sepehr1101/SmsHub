using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Line.Commands.Implementations
{
    public class ProviderCommandService: IProviderCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Provider> _providers;
        public ProviderCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _providers = _uow.Set<Provider>();
        }
        public async Task Add(Provider provider)
        {
            await _providers.AddAsync(provider);
        }
        public async Task Add(ICollection<Provider> providers)
        {
            await _providers.AddRangeAsync(providers);
        }
        public void Delete(Provider provider)
        {
            _providers.Remove(provider);
        }
    }
}
