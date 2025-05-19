using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Line.Queries
{
    [Route("provider")]
    [ApiController]
    [Authorize]
    public class ProviderGetSingleController : BaseController
    {
        private readonly IProviderGetSingleHandler _getSingleHandler;
        private readonly IUnitOfWork _uow;
        public ProviderGetSingleController(IProviderGetSingleHandler getSingleHandler,
            IUnitOfWork uow)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route("single")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetProviderDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LineSection, LogLevelMessageResources.Provider + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetSingle([FromBody] ProviderEnum Id, CancellationToken cancellationToken)
        {
            var provider = await _getSingleHandler.Handle(Id);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(provider);
        }
    }
}
