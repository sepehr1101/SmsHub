using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Line.Handlers.Queries.Contracts
{
    public interface IProviderGetSingleHandler
    {
        Task<GetProviderDto> Handle(ProviderEnum Id);
    }
}
