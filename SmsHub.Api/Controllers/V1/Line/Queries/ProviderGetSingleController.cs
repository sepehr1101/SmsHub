using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Line.Queries
{
    [Route("provider")]
    [ApiController]
    public class ProviderGetSingleController : BaseController
    {
        private readonly IProviderGetSingleHandler _getSingleHandler;
        public ProviderGetSingleController(IProviderGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route("single")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetProviderDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetSingle([FromBody] ProviderEnum Id)
        {
            var provider = await _getSingleHandler.Handle(Id);
            return Ok(provider);
        }
    }
}
