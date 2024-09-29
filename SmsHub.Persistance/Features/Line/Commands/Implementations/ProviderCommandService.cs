using Microsoft.EntityFrameworkCore;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands;

namespace SmsHub.Persistence.Features.Line.Commands.Implementations
{
    public class ProviderCommandService: IProviderCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Provider> _providers;
        public ProviderCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _providers = _uow.Set<Entities.Provider>();
        }
        public async Task Add(Entities.Provider provider)
        {
            await _providers.AddAsync(provider);
        }
        public async Task Add(ICollection<Entities.Provider> providers)
        {
            await _providers.AddRangeAsync(providers);
        }
    }
}
