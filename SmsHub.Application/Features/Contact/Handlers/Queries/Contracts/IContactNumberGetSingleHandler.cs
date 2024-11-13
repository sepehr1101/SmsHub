using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Contracts
{
    public interface IContactNumberGetSingleHandler
    {
        Task<GetContactNumberDto> Handle(IntId Id);
    }
}
