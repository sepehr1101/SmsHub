using MediatR;
using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands
{
    public record DeleteProviderDto : IRequest
    {
        public ProviderEnum Id { get; init; }
    }
}
