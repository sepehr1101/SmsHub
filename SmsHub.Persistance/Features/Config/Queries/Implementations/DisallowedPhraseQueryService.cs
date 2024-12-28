using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Queries.Implementations
{
    public class DisallowedPhraseQueryService: IDisallowedPhraseQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<DisallowedPhrase> _disallowedPhrases;

        public DisallowedPhraseQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _uow.NotNull(nameof(_uow));

            _disallowedPhrases=_uow.Set<DisallowedPhrase>();
        }
        public async Task<ICollection<DisallowedPhrase>> Get()
        { 
            return await _disallowedPhrases.ToListAsync();
        }
        public async Task<DisallowedPhrase> Get(int id)
        {
         return await _uow.FindOrThrowAsync<DisallowedPhrase>(id);
        }
    }
}
