using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts
{
    public interface IContactDeleteHandler
    {
        Task Handle(DeleteContactDto deleteContactDto, CancellationToken cancellationToken);
    }
}
