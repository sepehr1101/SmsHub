using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessageDetailStatus))]
    [ApiController]
    public class MessageDetailStatusGetAllController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageDetailStatusGetAllHandler _messageDetailStatusGetAllHandler;
        public MessageDetailStatusGetAllController(
            IUnitOfWork uow,
            IMessageDetailStatusGetAllHandler messageDetailStatusGetAllHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _messageDetailStatusGetAllHandler = messageDetailStatusGetAllHandler;
            _messageDetailStatusGetAllHandler.NotNull(nameof(messageDetailStatusGetAllHandler));
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var messageDetailStatus = await _messageDetailStatusGetAllHandler.Handle();
            return Ok(messageDetailStatus);
        }
    }
}
