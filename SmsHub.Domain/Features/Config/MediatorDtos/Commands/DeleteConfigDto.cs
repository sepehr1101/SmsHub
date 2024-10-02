using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public  record DeleteConfigDto : IRequest
    {
        public int Id { get; init; }

    }
}
