using MediatR;
using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete
{
    public record DeleteProviderDto  
    {
        public ProviderEnum Id { get; init; }
    }
}
