using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(InformativeLog))]
    [ApiController]
    [Authorize]
    public class InformativeLogGetSingleController : BaseController
    {
        private readonly IInformativeLogGetSingleHandler _getSingleHandler;
        private readonly IUnitOfWork _uow;
        public InformativeLogGetSingleController(
            IInformativeLogGetSingleHandler getSingleHandler, 
            IUnitOfWork uow)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetInforamtaiveLogDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LoggingSection, LogLevelMessageResources.InformativeLog + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> GetSingle([FromBody] LongId Id, CancellationToken cancellationToken)
        {
            var informativeLog = await _getSingleHandler.Handle(Id);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(informativeLog);
        }
    }
}
