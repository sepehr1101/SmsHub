using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts
{
    public interface IContactNumberDeleteHandler
    {
        Task Handle(DeleteContactNumberDto deleteContactNumberDto, CancellationToken cancellationToken);
    }
}
