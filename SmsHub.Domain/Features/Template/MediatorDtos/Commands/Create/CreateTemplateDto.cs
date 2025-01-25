namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create
{
    public record CreateTemplateDto
    {
        public string Expression { get; init; } = null!;
        public string Title { get; init; } = null!;
        public int TemplateCategoryId { get; init; }
        public bool IsActive { get; init; }
        public int MinCredit { get; init; }
        public int? ConfigTypeGroupId { get; set; }

    }
}
