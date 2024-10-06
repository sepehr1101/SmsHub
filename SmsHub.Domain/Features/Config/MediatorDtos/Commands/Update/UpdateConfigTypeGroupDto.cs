namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Update
{
    public record UpdateConfigTypeGroupDto
    {//todo: check Prop
        public int Id { get; set; }
        public short ConfigTypeId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
