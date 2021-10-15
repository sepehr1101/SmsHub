using System;

namespace SmsHub.Rahyab.Dtos.Output
{
    public class SendOutput
    {
        public string Code { get; set; }
        public Guid Identity { get; set; }
        public string errorMsg { get; set; }
    }
}
