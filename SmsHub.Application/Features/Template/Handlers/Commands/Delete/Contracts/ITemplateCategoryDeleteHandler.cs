using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Delete.Contracts
{
    public interface ITemplateCategoryDeleteHandler
    {
        Task Handle(DeleteTemplateCategoryDto deleteTemplateCategoryDto, CancellationToken cancellationToken);
    }
}
