
namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands
{
    public record UpdateTemplateCategoryDto  
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
        public int ConfigTypeGroupId { get; set; }

    }
}
