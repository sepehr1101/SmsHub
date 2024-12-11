namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface ISendManagerCreateHandler
    {
        Task Handle(int templateId,int lineId, CancellationToken cancellationToken);
    }
}
