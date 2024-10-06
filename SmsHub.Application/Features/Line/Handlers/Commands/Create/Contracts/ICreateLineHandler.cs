using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts
{
    public interface ICreateLineHandler
    {
        Task Handle(CreateLineDto request, CancellationToken cancellationToken);
    }
}