﻿using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record CreateConfigTypeDto : IRequest//todo: record or class?
    {
        public string? Title { get; set; } 
        public string? Description { get; set; } 
    }
}