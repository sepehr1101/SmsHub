using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Contracts;

namespace SmsHub.Persistence.Features.Config.Commands.Implementations
{
    public class DisallowedPhraseCommandService : IDisallowedPhraseCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<DisallowedPhrase> _disallowedPhrases;
        public DisallowedPhraseCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _disallowedPhrases = _uow.Set<DisallowedPhrase>();
        }

        public async Task Add(DisallowedPhrase disallowedPhrase)
        {
            await _disallowedPhrases.AddAsync(disallowedPhrase);
        }
        public async Task Add(ICollection<DisallowedPhrase> disallowedPhrase)
        {
            await _disallowedPhrases.AddRangeAsync(disallowedPhrase);
        }
        public void Delete(DisallowedPhrase disallowedPhrase)
        {
            _disallowedPhrases.Remove(disallowedPhrase);
        }

    }
}
