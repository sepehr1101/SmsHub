using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts
{
    public interface IUpdateContactNumberCategoryHandler
    {
        Task Handle(UpdateContactNumberCategoryDto updateContactNumberCategoryDto, CancellationToken cancellationToken);
    }
}
