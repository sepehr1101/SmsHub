using MediatR;
using SmsHub.Domain.Constants;
using System.Reflection.Metadata.Ecma335;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create
{
    public record CreateLineDto : IRequest
    {
        public ProviderEnum ProviderId { get; set; }
        public string? Number { get; set; }
        public string? Credential { get; set; }
    }
}
