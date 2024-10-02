namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands
{
   public record UpdateTemplateDto
    {//todo: check Prop
        public int Id { get; set; }
        public string Expression { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int TemplateCategoryId { get; set; }
        public bool IsActive { get; set; }
        public string Parameters { get; set; } = null!;
        public int MinCredit { get; set; }
    }
}
