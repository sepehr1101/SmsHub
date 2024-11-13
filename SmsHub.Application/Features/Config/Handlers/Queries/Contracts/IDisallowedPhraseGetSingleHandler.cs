using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Contracts
{
   public interface IDisallowedPhraseGetSingleHandler
    {
        Task<GetDisallowedPhraseDto> Handle(IntId Id);
    }
}
