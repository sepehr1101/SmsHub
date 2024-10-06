using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Contracts
{
    public interface ICcSendGetSingleHandler
    {
        Task<GetCcSendDto> Handle(int Id);
    }
}
