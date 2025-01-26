using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route(nameof(CcSend))]
    [ApiController]
    public class CcSendGetListController : BaseController
    {
        private readonly ICcSendGetListHandler _getListHandler;
        public CcSendGetListController(ICcSendGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetCcSendDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList()
        {
            var ccSends = await _getListHandler.Handle();
            return Ok(ccSends);
        }
    }
}
