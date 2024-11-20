using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
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
        public async Task<IActionResult> GetList()//Task<ICollection<GetCcSendDto>>
        {
            var ccSends = await _getListHandler.Handle();
            return Ok(ccSends);// return ccSends;
        }
    }
}
