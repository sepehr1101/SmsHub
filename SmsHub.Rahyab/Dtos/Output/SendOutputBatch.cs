using System;
using System.Collections.Generic;

namespace SmsHub.Rahyab.Dtos.Output
{
    public class SendOutputBatch
    {
        public ICollection<SubmitResponse> SubmitResponse { get; set; }
        public Guid BatchId { get; set; }
    }
}
