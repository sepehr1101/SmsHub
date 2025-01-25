namespace SmsHub.Domain.Features.Template.MediatorDtos.Queries
{
    public record TemplateDictionary
    {
        public int Id { get; init; }
        public string Title { get; init; }

        public TemplateDictionary(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
