﻿namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record UpdateDisallowedPhraseDto
    {//todo: check Prop
        public int Id { get; set; }
        public int ConfigTypeGroupId { get; set; }
        public string Phrase { get; set; } = null!;
    }
}