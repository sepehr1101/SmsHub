﻿using SmsHub.Domain.Features.Receiving.Entities;

namespace SmsHub.Persistence.Features.Receiving.Commands.Contracts
{
    public interface IReceiveCommandService
    {
        Task<Received> Add(Received receive);
        Task<ICollection<Received>> Add(ICollection<Received> receive);
    }
}