using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Api.Controllers.V1.Line.Queries
{
    [Route("line")]
    [ApiController]
    public class LineGetListController : BaseController
    {
        private readonly ILineGetListHandler _getListHandler;
        public LineGetListController(ILineGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route("all")]
        public async Task<IActionResult> GetList()
        {
            var lines = await _getListHandler.Handle();
            return Ok(lines);
        }
    }
}
