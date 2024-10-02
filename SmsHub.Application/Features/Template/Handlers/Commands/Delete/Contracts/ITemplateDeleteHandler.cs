using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Delete.Contracts
{
    public interface ITemplateDeleteHandler
    {
        Task Handle(DeleteTemplateDto deleteTemplateDto, CancellationToken cancellationToken);
    }
}
