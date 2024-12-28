using SmsHub.Domain.Providers.Asanak.Entities.Base;

namespace SmsHub.Domain.Providers.Asanak.Entities.Responses
{
    public class MsgStatusDto:ResponseBase
    {
        public DataDto Data {  get; set; }
    }
    public class DataDto
    {
        public long MsgId { get; set; }
        public int Status { get; set; }
        public string SendTime { get; set; }
        public string DeliverTime { get; set; }
        public long UserId { get; set; }
    }
}
