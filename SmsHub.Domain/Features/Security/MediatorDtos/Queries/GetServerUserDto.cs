﻿using MediatR;

namespace SmsHub.Domain.Features.Security.MediatorDtos.Queries
{
    public record GetServerUserDto:IRequest
    {
        public int Id { get; init; }
        public string Username { get; init; } = null!;
        public bool IsAdmin { get; init; }
        public DateTime CreateDateTime { get; init; }
        public DateTime? DeleteDateTime { get; init; }
        public string ApiKeyHash { get; init; } = null!;
    }
}