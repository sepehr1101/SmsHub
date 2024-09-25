using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class DisallowedPhraseQueryService: IDisallowedPhraseQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.DisallowedPhrase> _disallowedPhrases;

        public DisallowedPhraseQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _disallowedPhrases=_uow.Set<Entities.DisallowedPhrase>();
        }
        public async Task<ICollection<Entities.DisallowedPhrase>> Get()
        {
            var entities = await _disallowedPhrases.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.DisallowedPhrase));
            return entities;    
        }
        public async Task<Entities.DisallowedPhrase> Get(int id)
        {
            var entity=await _disallowedPhrases.FindAsync(id);
            entity.NotNull(nameof(Entities.DisallowedPhrase));
            return entity;
        }
    }
}
