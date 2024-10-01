namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public class UpdateConsumerDto
    {//todo: check Prop
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ApiKey { get; set; } = null!;
    }
}
