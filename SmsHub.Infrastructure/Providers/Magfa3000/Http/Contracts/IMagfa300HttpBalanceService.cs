﻿using SmsHub.Domain.Providers.Magfa3000.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa300HttpBalanceService
    {
        Task<BalanceDto> GetBalances(string domain, string username, string password);
    }
}
