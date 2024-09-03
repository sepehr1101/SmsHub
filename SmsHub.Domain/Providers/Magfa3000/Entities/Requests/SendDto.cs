namespace SmsHub.Domain.Providers.Magfa3000.Entities.Requests
{
    public class SendDto
    {
        public ICollection<string> Sender { get; set; }
        public ICollection<string> Recipients { get; set; }
        public ICollection<string> Messages { get; set; }
        //public int Encodings { get; set; }
        public ICollection<long> Uids { get; set; }
       // public string Udhs {  get; set; }// todo: we do not need
    }
}
