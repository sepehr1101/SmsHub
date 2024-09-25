using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Create.Contracts
{
    public interface ICreateTemplateHandler
    {
        Task Handle(CreateTemplateDto request, CancellationToken cancellationToken);
    }
}