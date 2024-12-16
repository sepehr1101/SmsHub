using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface ISendManagerCreateHandler
    {
        Task<ICollection<MobileText>> Handle(int templateId,int lineId,int batchSize, CancellationToken cancellationToken);
    }
}
