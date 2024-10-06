using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Contracts
{
    public interface ICcSendGetListHandler
    {
        Task<ICollection<GetCcSendDto>> Handle();
    }
}