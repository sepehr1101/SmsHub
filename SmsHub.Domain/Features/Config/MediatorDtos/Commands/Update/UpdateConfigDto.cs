﻿using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record UpdateConfigDto : IRequest
    {
        public int Id { get; init; }
        public int ConfigTypeGroupId { get; init; }
        public int TemplateId { get;init; }
    }
}