using SmsHub.Domain.Features.Line.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Update.Contracts
{
    public interface IUpdateLineHandler
    {
        Task Handle(UpdateLineDto updateLineDto, CancellationToken cancellationToken);
    }
}
