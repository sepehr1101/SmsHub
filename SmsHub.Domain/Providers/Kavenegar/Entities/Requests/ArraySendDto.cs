namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class ArraySendDto
    {
        public ICollection<string> Receptor { get; set; } = default!;
        public ICollection<string> Sender { get; set; } = default!;
        public ICollection<string>  Message { get; set; } = default!;
        public long? Date { get; set; }
        public ICollection<int>? Type { get; set; }
        public ICollection<long>? LocalMessageIds { get; set; }
        public short Hide { get; set; }

    }
}
