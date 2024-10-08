using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts
{
    public interface IContactDeleteHandler
    {
        Task Handle(DeleteContactDto deleteContactDto, CancellationToken cancellationToken);
    }
}
