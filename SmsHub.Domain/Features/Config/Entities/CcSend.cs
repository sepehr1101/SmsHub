﻿namespace SmsHub.Domain.Features.Entities
{
    public class CcSend
    {
        public int Id { get; set; }
        public int ConfigTypeGroupId { get; set; }
        public string Mobile { get; set; } = null!;

        public virtual ConfigTypeGroup ConfigTypeGroup { get; set; } = null!;
    }
}