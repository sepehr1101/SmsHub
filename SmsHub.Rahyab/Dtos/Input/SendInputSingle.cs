using SmsHub.Rahyab.Dtos.Base;

namespace SmsHub.Rahyab.Dtos.Input
{
    public class SendInputSingle : UserPassCompanyNumber
    {
        public string Message { get; set; }
        public string MessageId { get; set; }
        public string DestinationAddress { get; set; }
    }
}
