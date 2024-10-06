using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Queries
{
    public record GetCcSendDto:IRequest
    {
        public int Id { get; init; }
        public int ConfigTypeGroupId { get; init; }
        public string Mobile { get; init; } = null!;
    }
}
