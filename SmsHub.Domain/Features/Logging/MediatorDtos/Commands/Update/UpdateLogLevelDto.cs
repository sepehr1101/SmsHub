namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Update
{
    public record UpdateLogLevelDto
    {//todo: check Prop
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Css { get; set; } = null!;
    }
}
