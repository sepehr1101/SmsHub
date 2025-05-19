using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Config.Handlers.Queries.Implementations;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Commands.Create
{
    [Route("disallowed-phrase")]
    [ApiController]
    [Authorize]
    public class DisallowedPhraseCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IDisallowedPhraseCreateHandler _createCommandHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;
        private readonly IConfigTypeGroupGetSingleHandler _configTypeGroupGetSingleHandler;
        public DisallowedPhraseCreateController(
            IUnitOfWork uow,
            IDisallowedPhraseCreateHandler createCommandHandler,
            IInformativeLogCreateHandler informativeLogCreateHandler,
            IConfigTypeGroupGetSingleHandler  configTypeGroupGetSingleHandler)
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
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateDisallowedPhraseDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.DisallowedPhrase+LogLevelMessageResources.SendConfigSection)]
        public async Task<IActionResult> Create([FromBody] CreateDisallowedPhraseDto createDto, CancellationToken cancellationToken)
        {
            IntId configTypeGroupId = createDto.ConfigTypeGroupId;
            var configTypeGroup = await _configTypeGroupGetSingleHandler.Handle(configTypeGroupId);

            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }

}
