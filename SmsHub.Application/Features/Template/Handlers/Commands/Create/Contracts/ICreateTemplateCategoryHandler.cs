using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Create.Contracts
{
    public interface ICreateTemplateCategoryHandler
    {
        Task Handle(CreateTemplateCategoryDto request, CancellationToken cancellationToken);
    }
}