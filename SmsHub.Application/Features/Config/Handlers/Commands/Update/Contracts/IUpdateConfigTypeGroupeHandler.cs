﻿using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts
{
    public interface IUpdateConfigTypeGroupeHandler
    {
        Task Handle(UpdateConfigTypeGroupDto updateConfigTypeGroupDto, CancellationToken cancellationToken);
    }
}