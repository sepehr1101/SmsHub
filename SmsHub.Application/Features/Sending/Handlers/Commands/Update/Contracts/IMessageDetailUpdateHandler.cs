﻿using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts
{
    public interface IMessageDetailUpdateHandler
    {
        Task Handle(UpdateMessageDetailDto updateMessageDetailDto, CancellationToken cancellationToken);
    }
}
