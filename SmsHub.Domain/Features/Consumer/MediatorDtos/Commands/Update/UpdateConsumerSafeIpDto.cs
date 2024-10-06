namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Update
{
    public class UpdateConsumerSafeIpDto
    {//todo: check Prop
        public int Id { get; set; }
        public int ConsumerId { get; set; }
        public string FromIp { get; set; } = null!;
        public string ToIp { get; set; } = null!;
        public bool IsV6 { get; set; }
    }
}
