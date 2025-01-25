namespace SmsHub.Domain.Features.Line.MediatorDtos.Queries
{
    public record LineDictionary
    {
       public int Id { get; init; }
        public string LineNumber { get; init; }
        public LineDictionary(int id,string lineNumber)
        {
            Id=id;
            LineNumber=lineNumber;  
        }
    }
}
