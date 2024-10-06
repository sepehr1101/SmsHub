using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Line.Handlers.Queries.Contracts
{
    public interface ILineGetListHandler
    {
        Task<ICollection<GetLineDto>> Handle();
    }
}
