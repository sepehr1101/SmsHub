using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Template.Querries
{
    [Route(nameof(Template))]
    [ApiController]
    public class TemplateGetListController : ControllerBase
    {
        private readonly ITemplateGetListHandler _getListHandler;
        public TemplateGetListController(ITemplateGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetTemplateDto>> GetList()
        {
            var Templates = await _getListHandler.Handle();
            return Templates;
        }
    }
}
