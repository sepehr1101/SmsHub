﻿using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts
{
    public interface IUpdateLogLevelHandler
    {
        Task Handle(UpdateLogLevelDto updateLogLevelDto, CancellationToken cancellationToken);
    }
}