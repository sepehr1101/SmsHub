namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Update
{
    public class UpdateConsumerLineDto
    {//todo: check Prop
        public int Id { get; set; }
        public int ConsumerId { get; set; }
        public int LineId { get; set; }
    }
}
