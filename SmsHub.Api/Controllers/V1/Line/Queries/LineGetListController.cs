using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Line.Queries
{
    [Route(nameof(Line))]
    [ApiController]
    public class LineGetListController : ControllerBase
    {
        private readonly ILineGetListHandler _getListHandler;
        public LineGetListController(ILineGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetLineDto>> GetList()
        {
            var lines = await _getListHandler.Handle();
            return lines;
        }
    }
}
