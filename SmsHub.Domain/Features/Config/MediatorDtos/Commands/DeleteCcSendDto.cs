using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record DeleteCcSendDto : IRequest
    {
        public int  Id { get; init; }
    }
}
