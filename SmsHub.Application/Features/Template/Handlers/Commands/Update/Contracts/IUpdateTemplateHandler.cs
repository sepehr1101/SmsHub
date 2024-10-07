using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts
{
    public interface IUpdateTemplateHandler
    {
        Task Handle(UpdateTemplateDto updateTemplateDto, CancellationToken cancellationToken);
    }
}
