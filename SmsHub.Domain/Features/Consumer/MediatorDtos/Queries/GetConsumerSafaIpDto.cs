﻿namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Queries
{
    public record GetConsumerSafaIpDto 
    {
        public int Id { get; init; }
        public int ConsumerId { get; init; }
        public string FromIp { get; init; } = null!;
        public string ToIp { get; init; } = null!;
        public bool IsV6 { get; init; }
    }
}
