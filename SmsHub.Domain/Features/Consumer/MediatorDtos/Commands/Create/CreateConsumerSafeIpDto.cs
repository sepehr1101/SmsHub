﻿using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create
{
    public record CreateConsumerSafeIpDto : IRequest
    {
        public int ConsumerId { get; set; }
        public string? FromIp { get; set; }
        public string? ToIp { get; set; }
        public bool IsV6 { get; set; }
    }
}