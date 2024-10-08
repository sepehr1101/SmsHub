﻿using SmsHub.Domain.Providers.Magfa3000.Entities.Base;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class StatusesDto:ResponseBase
    {
        public ICollection<DlrsDto> Dlrs { get; set; }

    }
    public class DlrsDto
    {
        public long Mid { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}
