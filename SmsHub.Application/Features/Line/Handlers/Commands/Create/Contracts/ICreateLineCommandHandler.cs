using SmsHub.Domain.Features.Line.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts
{
    public interface ICreateLineCommandHandler
    {
        Task Handle(CreateLineDto request, CancellationToken cancellationToken);
    }
}