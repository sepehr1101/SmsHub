using SmsHub.Domain.Features.Template.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts
{
    public interface ITemplateCategoryUpdateHandler
    {
        Task Handle(UpdateTemplateCategoryDto updateTemplateCategoryDto, CancellationToken cancellationToken);
    }
}
