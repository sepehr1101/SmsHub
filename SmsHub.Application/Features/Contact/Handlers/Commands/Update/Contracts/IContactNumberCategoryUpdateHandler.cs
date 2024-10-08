using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts
{
    public interface IContactNumberCategoryUpdateHandler
    {
        Task Handle(UpdateContactNumberCategoryDto updateContactNumberCategoryDto, CancellationToken cancellationToken);
    }
}
