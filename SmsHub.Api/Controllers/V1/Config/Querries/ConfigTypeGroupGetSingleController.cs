using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route("config-type-group")]
    [ApiController]
    [Authorize]
    public class ConfigTypeGroupGetSingleController : BaseController
    {
        private readonly IConfigTypeGroupGetSingleHandler _getSingleHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;
        private readonly IUnitOfWork _uow;

        public ConfigTypeGroupGetSingleController(
            IConfigTypeGroupGetSingleHandler getSingleHandler, 
            IInformativeLogCreateHandler informativeLogCreateHandler, 
            IUnitOfWork uow)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route("single")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetConfigTypeGroupDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.ConfigTypeGroup + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id, CancellationToken cancellationToken)
        {
            var configTypeGroup = await _getSingleHandler.Handle(Id);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(configTypeGroup);
        }
    }
}
