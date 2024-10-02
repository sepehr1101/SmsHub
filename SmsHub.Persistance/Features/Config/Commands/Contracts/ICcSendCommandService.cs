using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Contracts
{
    public interface ICcSendCommandService
    {
        Task Add(CcSend ccSend);
        Task Add(ICollection<CcSend> ccSends);
        void Delete(CcSend ccSend);
    }
}
