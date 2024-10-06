using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Line.Handlers.Queries.Contracts
{
    public interface IProviderGetListHandler
    {
        Task<ICollection<GetProviderDto>> Handle();
    }
}
