using SmsHub.Application.Features.Config.Handlers.Queries.Implementations;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Contracts
{
    public interface IPermittedTimeGetSingleHandler
    {
        Task<GetPermittedTimeDto> Handle(int Id);
    }
}
