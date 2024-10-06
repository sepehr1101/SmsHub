using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Contracts
{
   public interface IDisallowedPhraseGetSingleHandler
    {
        Task<GetDisallowedPhraseDto> Handle(int Id);
    }
}
