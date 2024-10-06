using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
   public record DeleteMessageStateCategoryDto : IRequest
    {
        public int Id { get; init; }
    }
}
