﻿using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts
{
    public interface IConfigUpdateHandler
    {
        Task Handle(UpdateConfigDto updateConfigDto, CancellationToken cancellationToken);
    }
}
