using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Receiving.Entities
{
    [Table(nameof(Receive))]
    public class Receive
    {
        public long Id { get; set; }
        public long? MessageId { get; set; }
        public int? Status { get; set; }
        public string MessageText { get; set; }
        public string Sender {  get; set; }
        public string Receptor {  get; set; }
        public DateTime ReceiveDateTime {  get; set; }
        public DateTime InsertDateTime {  get; set; }

    }
}
