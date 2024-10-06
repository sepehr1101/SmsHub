namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record UpdateConfigTypeDto
    {
        public short Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
    }
}
