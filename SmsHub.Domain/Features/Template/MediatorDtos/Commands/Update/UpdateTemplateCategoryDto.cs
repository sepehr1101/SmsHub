namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands.Update
{
    public record UpdateTemplateCategoryDto
    {//todo: check Prop
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
