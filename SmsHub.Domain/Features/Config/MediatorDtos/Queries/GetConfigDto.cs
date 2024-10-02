using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Queries
{
   public record GetConfigDto:IRequest
    {
        public int Id { get; init; }
        public int ConfigTypeGroupId { get; init; }
        public int TemplateId { get; init; }

    }
}
