using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Contracts
{
    public interface IContactGetListHandler
    {
        Task<ICollection<GetContactDto>> Handle();
    }
}
