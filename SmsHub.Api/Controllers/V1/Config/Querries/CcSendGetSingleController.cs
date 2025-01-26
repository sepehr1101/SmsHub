using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route(nameof(CcSend))]
    [ApiController]
    public class CcSendGetSingleController : BaseController
    {
        private readonly ICcSendGetSingleHandler _getSingleHandler;
        public CcSendGetSingleController(ICcSendGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetCcSendDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var ccSend = await _getSingleHandler.Handle(Id);
            return Ok(ccSend);
        }
    }
}
