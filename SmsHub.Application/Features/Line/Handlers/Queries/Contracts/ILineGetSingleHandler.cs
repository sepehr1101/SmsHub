using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Line.Handlers.Queries.Contracts
{
    public interface ILineGetSingleHandler
    {
        Task<GetLineDto> Handle(IntId Id);
    }
}
