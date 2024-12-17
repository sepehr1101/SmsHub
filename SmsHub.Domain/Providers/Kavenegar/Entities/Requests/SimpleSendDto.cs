namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public record SimpleSendDto
    {
        public string Receptor { get; set; } = default!;
        public string Message { get; set; } = default!;
        public string? Sender { get; set; }
        public long? Date { get; set; }
        public string? @Type { get; set; }
        public long? LocalId { get; set; }
        public short? Hide { get; set; }
        public SimpleSendDto()
        {
            
        }
        public SimpleSendDto(string receptor, string message, string? sender)
        {
            Receptor = receptor;
            Message = message;
            Sender = sender;
        }
        public SimpleSendDto(string receptor, string message)
            :this(receptor, message, null)
        {
            
        }
    }
}
