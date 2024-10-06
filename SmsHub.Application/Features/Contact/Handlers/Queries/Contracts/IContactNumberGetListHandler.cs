using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Contracts
{
    public interface IContactNumberGetListHandler
    {
        Task<ICollection<GetContactNumberDto>> Handle();
    }
}
