namespace SmsHub.Persistence.Features.Config.Commands.Create.Contracts
{
    public interface ICcSendCommandService
    {
        Task Add(Domain.Features.Entities.CcSend ccSend);
        Task Add(ICollection<Domain.Features.Entities.CcSend> ccSends);
    }
}
