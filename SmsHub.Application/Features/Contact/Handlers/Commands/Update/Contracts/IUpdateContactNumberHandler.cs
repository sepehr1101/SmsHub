using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts
{
    public interface IUpdateContactNumberHandler
    {
        Task Handle(UpdateContactNumberDto updateContactNumberDto, CancellationToken cancellationToken);
    }
}
