using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts
{
    public interface IUpdateContactHandler
    {
        Task Handle(UpdateContactDto updateContactDto, CancellationToken cancellationToken);
    }
}
