﻿namespace SmsHub.Domain.Features.Entities
{
    public class PermittedTime
    {
        public int Id { get; set; }
        public int ConfigTypeGroupId { get; set; }
        public string FromTime { get; set; } = null!;
        public string ToTime { get; set; } = null!;

        public virtual ConfigTypeGroup ConfigTypeGroup { get; set; } = null!;
    }
}