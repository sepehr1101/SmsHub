using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts
{
    public interface IUpdateTemplateCategoryHandler
    {
        Task Handle(UpdateTemplateCategoryDto updateTemplateCategoryDto, CancellationToken cancellationToken);
    }
}
