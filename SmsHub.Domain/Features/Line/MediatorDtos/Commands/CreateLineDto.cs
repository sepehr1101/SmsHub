﻿using MediatR;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands
{
    public record CreateLineDto:IRequest
    {
        public short ProviderId { get; set; }
        public string? Number { get; set; }
        public short CredentialType { get; set; }
        public string? Credential { get; set; }
    }
}