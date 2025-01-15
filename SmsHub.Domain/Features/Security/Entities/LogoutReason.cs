using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Security.Entities;

public partial class LogoutReason
{
    public LogoutReasonEnum Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
