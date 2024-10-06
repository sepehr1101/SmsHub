using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Template.Handlers.Queries.Contracts
{
    public interface ITemplateCategoryGetSingleHandler
    {
        Task<GetTemplateCategoryDto> Handle(int Id);
    }
}