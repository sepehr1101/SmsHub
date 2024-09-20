using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(ServerUser))]
    public class ServerUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        public string ApiKeyHash { get; set; } = null!;
    }
}
