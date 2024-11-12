using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Contracts
{
    public interface IConfigGetSingleHandler
    {
        Task<GetConfigDto> Handle(IntId Id);
    }
}
