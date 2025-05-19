using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Line.Queries
{
    [Route("line")]
    [ApiController]
    public class LineGetSingleController : BaseController
    {
        private readonly ILineGetSingleHandler _getSingleHandler;
        public LineGetSingleController(ILineGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route("single")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetLineDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle(IntId Id)
        {
            var line = await _getSingleHandler.Handle(Id);
            return Ok(line);
        }
    }
}
