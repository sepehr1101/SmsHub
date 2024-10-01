namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record UpdateConfigDto
    {//todo: check Prop
        public int Id { get; set; }
        public int ConfigTypeGroupId { get; set; }
        public int TemplateId { get; set; }
    }
}
