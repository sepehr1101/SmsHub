﻿using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts
{
    public interface IMessageStateCategoryUpdateHandler
    {
        Task Handle(UpdateMessageStateCategoryDto updateMessageStateCategoryDto, CancellationToken cancellationToken);
    }
}
