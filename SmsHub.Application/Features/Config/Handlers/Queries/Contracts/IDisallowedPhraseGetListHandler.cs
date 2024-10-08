using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Contracts
{
    public interface IDisallowedPhraseGetListHandler
    {
        Task<ICollection<GetDisallowedPhraseDto>> Handle();
    }
}
