﻿using SmsHub.Domain.Constants;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface IStatusInBackgroundService
    {
        Task Trigger(Guid messageHolderId, ProviderEnum providerId);
    }
}