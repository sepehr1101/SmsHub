using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Sending.Entities
{
    [Table(nameof(ProviderDeliveryStatus))]
    public class ProviderDeliveryStatus
    {
        public int Id { get; set; }
        public ProviderEnum ProviderId { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsFinal { get; set; }

        public virtual Provider Provider { get; set; }
    }
}
