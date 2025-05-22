using SmsHub.Domain.Features.Security.Dtos.ApplicationUser;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface ISendManagerCreateHandler
    {
        Task<ICollection<MobileText>> Handle(int templateId,int lineId, IAppUser currentUser, CancellationToken cancellationToken);
    }
}
