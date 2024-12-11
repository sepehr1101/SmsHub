namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface ISendManagerCreateHandler
    {
        void Handle(int templateId, CancellationToken cancellationToken);
    }
}
