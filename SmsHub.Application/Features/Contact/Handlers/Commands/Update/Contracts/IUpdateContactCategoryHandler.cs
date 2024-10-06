using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts
{
    public interface IUpdateContactCategoryHandler
    {
        Task Handle(UpdateContactCategoryDto updateContactCategoryDto, CancellationToken cancellationToken);
    }
}
