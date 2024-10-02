using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record UpdateCcSendDto : IRequest
    {
        public int Id { get; init; }
        public int ConfigTypeGroupId { get; init; }
        public string Mobile { get; init; } = null!;
    }
}
