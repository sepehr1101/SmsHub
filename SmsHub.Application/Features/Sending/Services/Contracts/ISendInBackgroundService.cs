﻿using SmsHub.Domain.Constants;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISendInBackgroundService
    {
        Task Trigger(Guid messageHolderId, ProviderEnum providerId);
    }
}