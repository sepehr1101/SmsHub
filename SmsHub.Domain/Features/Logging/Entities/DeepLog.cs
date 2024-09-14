using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(DeepLog))]
    public class DeepLog
    {
        public long Id { get; set; }
        public int OperationTypeId { get; set; }
        public string PrimaryDb { get; set; } = null!;
        public string PrimaryTable { get; set; } = null!;
        public string PrimaryId { get; set; } = null!;
        public string? ValueBefore { get; set; }
        public string? ValueAfter { get; set; }
        public string Ip { get; set; } = null!;
        public DateTime InsertDateTime { get; set; }
        public string ClientInfo { get; set; } = null!;

        public virtual OperationType OperationType { get; set; } = null!;
    }
}
