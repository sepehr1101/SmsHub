﻿namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record UpdateCcSendDto
    {//todo: check Prop
        public int Id { get; set; }
        public int ConfigTypeGroupId { get; set; }
        public string Mobile { get; set; } = null!;
    }
}