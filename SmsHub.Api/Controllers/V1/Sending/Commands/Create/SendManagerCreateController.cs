using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using SmsHub.Persistence.Features.Line.Queries.Implementations;
using SmsHub.Persistence.Features.Template.Queries.Contracts;


namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [ApiController]
    [Route("Send")]
    [Authorize]
    public class SendManagerCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ISendManagerCreateHandler _sendManagerCreateHandler;
        private readonly ILineGetSingleHandler _lineGetSingleHandler;
        private readonly ITemplateGetSingleHandler _templateGetSingleHandler;
        public SendManagerCreateController(
           ITemplateGetSingleHandler templateGetSingleHandler,
           IUnitOfWork uow,
           ISendManagerCreateHandler sendManagerCreateHandler,
           ISmsProvider smsProvider,
           IKavenegarHttpStatusService statusService,
           ILineGetSingleHandler lineQueryService)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _templateGetSingleHandler = templateGetSingleHandler;
            _templateGetSingleHandler.NotNull(nameof(templateGetSingleHandler));

            _sendManagerCreateHandler = sendManagerCreateHandler;
            _sendManagerCreateHandler.NotNull(nameof(sendManagerCreateHandler));

            _lineGetSingleHandler = lineQueryService;
            _lineGetSingleHandler.NotNull(nameof(lineQueryService));

        }

        [HttpPost]
        [Route("by-template/{templateId}/{lineId}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<MobileText>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Send, LogLevelMessageResources.SendSection, LogLevelMessageResources.SendMessage + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> SendManager(int templateId, int lineId, CancellationToken cancellationToken)
        {
            var line = await _lineGetSingleHandler.Handle(lineId);
            var template=await _templateGetSingleHandler.Handle(templateId);

            var messages = await _sendManagerCreateHandler.Handle(templateId, lineId, new CancellationToken());
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(messages);
        }

    }

}