using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts
{
    public interface IContactNumberCategoryDeleteHandler
    {
        Task Handle(DeleteContactNumberCategoryDto deleteContactNumberCategoryDto, CancellationToken cancellationToken);
    }
}
