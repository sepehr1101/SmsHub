namespace SmsHub.Domain.Features.Security.Dtos
{
   public record GetUserLineByLineIdDto
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public string FullName{ get; set; }
    }
}
