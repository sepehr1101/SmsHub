using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Commands.Create
{
    [Route("cc-send")]
    [ApiController]
    [Authorize]
    public class CcSendCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ICcSendCreateHandler _createCommandHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;
        private readonly IConfigTypeGroupGetSingleHandler _configTypeGroupGetSingleHandler;
        public CcSendCreateController(
            IUnitOfWork uow,
            ICcSendCreateHandler createCommandHandler,
            IInformativeLogCreateHandler informativeLogCreateHandler,
            IConfigTypeGroupGetSingleHandler configTypeGroupGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));

            _configTypeGroupGetSingleHandler = configTypeGroupGetSingleHandler;
            _configTypeGroupGetSingleHandler.NotNull(nameof(configTypeGroupGetSingleHandler));
        }
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateCcSendDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.CcSend + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateCcSendDto createDto, CancellationToken cancellationToken)
        {
            IntId configTypeGroupId=createDto.ConfigTypeGroupId;
            var configTypeGroup = await _configTypeGroupGetSingleHandler.Handle(configTypeGroupId);
           
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}