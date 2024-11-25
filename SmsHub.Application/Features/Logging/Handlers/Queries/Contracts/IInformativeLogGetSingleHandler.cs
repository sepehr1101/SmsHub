using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Logging.Handlers.Queries.Contracts
{
    public interface IInformativeLogGetSingleHandler
    {
        Task<GetInforamtaiveLogDto> Handle(LongId Id);
    }
}
