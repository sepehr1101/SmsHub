using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Create.Contracts
{
    public interface ITemplateCreateHandler
    {
        Task Handle(CreateTemplateDto request, CancellationToken cancellationToken);
    }
}