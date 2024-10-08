using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts
{
    public interface IContactCreateHandler
    {
        Task Handle(CreateContactDto request, CancellationToken cancellationToken);
    }
}