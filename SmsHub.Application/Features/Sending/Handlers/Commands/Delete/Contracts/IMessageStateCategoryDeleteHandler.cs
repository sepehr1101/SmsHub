﻿using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts
{
    public interface IMessageStateCategoryDeleteHandler
    {
        Task Handle(DeleteMessageStateCategoryDto deleteMessageStateCategoryDto, CancellationToken cancellationToken);
    }
}