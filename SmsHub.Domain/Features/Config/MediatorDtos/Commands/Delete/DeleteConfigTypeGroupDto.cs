using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete
{
    public record DeleteConfigTypeGroupDto  
    {
        public int Id { get; init; }

    }
}
