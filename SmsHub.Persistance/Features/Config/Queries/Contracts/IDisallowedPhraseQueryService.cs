﻿using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface IDisallowedPhraseQueryService
    {
        Task<ICollection<DisallowedPhrase>> Get();
        Task<DisallowedPhrase> Get(int id);
    }
}
