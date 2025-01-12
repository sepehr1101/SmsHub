using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Queries
{
    public record GetLineDto 
    {
        public int Id { get; init; }
        public ProviderEnum ProviderId { get; init; }
        public string Number { get; init; } = null!;
        //public string Credential { get; init; } = null!; //todo: Remove
    }
}
