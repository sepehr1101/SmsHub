using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts
{
    public interface IContactNumberCategoryDeleteHandler
    {
        Task Handle(DeleteContactNumberCategoryDto deleteContactNumberCategoryDto, CancellationToken cancellationToken);
    }
}
