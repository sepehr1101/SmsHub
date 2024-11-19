using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Api.Controllers.V1.Template.Querries
{
    [Route(nameof(Template))]
    [ApiController]
    public class TemplateGetListController : BaseController
    {
        private readonly ITemplateGetListHandler _getListHandler;
        public TemplateGetListController(ITemplateGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var Templates = await _getListHandler.Handle();
            return Ok(Templates);
        }
    }
}
