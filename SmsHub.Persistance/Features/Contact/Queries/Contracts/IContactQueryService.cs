﻿using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Queries.Contracts
{
    public interface IContactQueryService
    {
        Task<ICollection<Entities.Contact>> Get();
        Task<Entities.Contact> Get(int id);
    }
}
