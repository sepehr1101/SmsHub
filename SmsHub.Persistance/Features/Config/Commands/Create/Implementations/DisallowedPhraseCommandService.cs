using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Create.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Create.Implementations
{
    public class DisallowedPhraseCommandService: IDisallowedPhraseCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.DisallowedPhrase> _disallowedPhrases;
        public DisallowedPhraseCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _disallowedPhrases = _uow.Set<Entities.DisallowedPhrase>();
        }

        public async Task Add(Entities.DisallowedPhrase disallowedPhrase)
        {
            await _disallowedPhrases.AddAsync(disallowedPhrase);
        }
        public async Task Add(ICollection<Entities.DisallowedPhrase> disallowedPhrase)
        {
            await _disallowedPhrases.AddRangeAsync(disallowedPhrase);
        }
    }
}
