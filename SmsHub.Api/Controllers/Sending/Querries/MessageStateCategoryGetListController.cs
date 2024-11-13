using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Sending.Querries
{
    [Route(nameof(MessageStateCategory))]
    [ApiController]
    public class MessageStateCategoryGetListController : ControllerBase
    {
        private readonly IMessageStateCategoryGetListHandler _getListHandler;
        public MessageStateCategoryGetListController(IMessageStateCategoryGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetMessageStateCategoryDto>> GetList()
        {
            var messageStateCategories = await _getListHandler.Handle();
            return messageStateCategories;
        }
    }
}
