﻿using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface IMessageDetailCreateHandler
    {
        Task Handle(CreateMessageDetailDto request, CancellationToken cancellationToken);
    }
}