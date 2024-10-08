﻿using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create
{
    public record CreateDisallowedPhraseDto : IRequest
    {
        public int ConfigTypeGroupId { get; init; }
        public string? Phrase { get; init; } 
    }
}
