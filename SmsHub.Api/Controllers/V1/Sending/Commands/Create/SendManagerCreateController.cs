using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [ApiController]
    [Route("Send")]
    [Authorize]
    public class SendManagerCreateController : BaseController
    {       
        private readonly ISendManagerCreateHandler _sendManagerCreateHandler;
        public SendManagerCreateController(
           ISendManagerCreateHandler sendManagerCreateHandler)
        {
            _sendManagerCreateHandler = sendManagerCreateHandler;
            _sendManagerCreateHandler.NotNull(nameof(sendManagerCreateHandler));
        }

        [HttpPost]
        [Route("by-template/{templateId}/{lineId}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<MobileText>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Send, LogLevelMessageResources.SendSection, LogLevelMessageResources.SendMessage + LogLevelMessageResources.AttemptDescription)]
        public async Task<IActionResult> SendManager(int templateId, int lineId, CancellationToken cancellationToken)
        {  
            var messages = await _sendManagerCreateHandler.Handle(templateId, lineId, CurrentUser, cancellationToken);
            return Ok(messages);
        }
    }

}