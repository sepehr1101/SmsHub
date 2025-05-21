namespace SmsHub.Domain.Features.Security.Dtos
{
    public record UserQueryDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public ICollection<int> RoleId { get; set; } = new List<int>();
        public string Mobile { get; set; } = null!;
        public bool MobileConfirmed { get; set; }
        public bool HasTwoStepVerification { get; set; }
        public int InvalidLoginAttemptCount { get; set; }
        public DateTime? LatestLoginDateTime { get; set; }
        public DateTime? LockTimespan { get; set; }
    }
}