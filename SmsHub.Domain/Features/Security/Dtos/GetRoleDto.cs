namespace SmsHub.Domain.Features.Security.Dtos
{
    public record GetRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Title { get; set; } = null!;
    }
}
