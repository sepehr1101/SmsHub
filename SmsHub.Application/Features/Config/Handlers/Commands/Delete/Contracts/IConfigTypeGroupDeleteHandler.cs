﻿using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts
{
    public interface IConfigTypeGroupDeleteHandler
    {
        Task Handle(DeleteConfigTypeGroupDto deleteConfigTypeGroupDto, CancellationToken cancellationToken);

    }
}