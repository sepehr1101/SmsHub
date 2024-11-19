using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessageStateCategory))]
    [ApiController]
    public class MessageStateCategoryGetListController : BaseController
    {
        private readonly IMessageStateCategoryGetListHandler _getListHandler;
        public MessageStateCategoryGetListController(IMessageStateCategoryGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var messageStateCategories = await _getListHandler.Handle();
            return Ok(messageStateCategories);
        }
    }
}
