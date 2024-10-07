using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Create.Contracts
{
    public interface ITemplateCategoryCreateHandler
    {
        Task Handle(CreateTemplateCategoryDto request, CancellationToken cancellationToken);
    }
}