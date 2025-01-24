using System.ComponentModel.DataAnnotations.Schema;
using Entity = SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Sending.Entities
{
    [Table(nameof(Received))]
    public class Received
    {
        public long Id { get; set; }
        public long? MessageId { get; set; }
        public string MessageText { get; set; }
        public string Sender {  get; set; }
        public string Receptor {  get; set; }
        public DateTime ReceiveDateTime {  get; set; }
        public DateTime InsertDateTime {  get; set; }
        public int LineId {  get; set; }

        public virtual Entity.Line Line { get; set; } = null!;


    }
}
