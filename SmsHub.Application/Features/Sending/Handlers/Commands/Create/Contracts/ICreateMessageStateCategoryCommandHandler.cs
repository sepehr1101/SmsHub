﻿using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface ICreateMessageStateCategoryCommandHandler
    {
        Task Handle(CreateMessageStateCategoryDto request, CancellationToken cancellationToken);
    }
}