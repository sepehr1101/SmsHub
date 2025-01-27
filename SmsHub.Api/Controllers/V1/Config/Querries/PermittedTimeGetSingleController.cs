using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route("permitted-time")]
    [ApiController]
    public class PermittedTimeGetSingleController : BaseController
    {
        private readonly IPermittedTimeGetSingleHandler _getSingleHandler;
        public PermittedTimeGetSingleController(IPermittedTimeGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route("single")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetPermittedTimeDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var permittedTime = await _getSingleHandler.Handle(Id);
            return Ok(permittedTime);
        }
    }
}
