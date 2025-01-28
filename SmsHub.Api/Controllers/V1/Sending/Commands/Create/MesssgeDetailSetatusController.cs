using Aban360.Api.Controllers.V1;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [Route(nameof(MessageDetailStatus))]
    [ApiController]
    [Authorize]
    public class MesssgeDetailSetatusController:BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageDetailStatusCreateHandler _messageDetailStatusCreateHandler;
        public MesssgeDetailSetatusController(
            IUnitOfWork uow,
            IMessageDetailStatusCreateHandler messageDetailStatusCreateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _messageDetailStatusCreateHandler = messageDetailStatusCreateHandler;
            _messageDetailStatusCreateHandler.NotNull(nameof(messageDetailStatusCreateHandler));
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateMessageDetailStatusDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageDetailStatus + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateMessageDetailStatusDto request, CancellationToken cancellationToken)
        {
           await _messageDetailStatusCreateHandler.Handle(request, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok();
        }
    }
}
