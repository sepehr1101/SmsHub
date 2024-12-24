namespace SmsHub.Domain.Providers.Magfa3000.Entities.Requests
{
    public class SendDto
    {
        public ICollection<string> senders { get; set; }
        public ICollection<string> recipients { get; set; }
        public ICollection<string> messages { get; set; }
        //public int Encodings { get; set; }
        public ICollection<long> uids { get; set; }
       // public string Udhs {  get; set; }// todo: we do not need
    }
}
