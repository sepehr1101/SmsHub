using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Contracts
{
    public interface IMessageHolderGetSingleHandler
    {
        Task<GetMessageHolderDto> Handle(GuidId Id);
    }
}
