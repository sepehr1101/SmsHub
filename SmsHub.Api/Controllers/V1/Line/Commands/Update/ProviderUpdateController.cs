using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Line.Commands.Update
{
    [Route("provider")]
    [ApiController]
    [Authorize]
    public class ProviderUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IProviderUpdateHandler _updateProviderHandler;
        public ProviderUpdateController(
            IUnitOfWork uow,
            IProviderUpdateHandler updateProviderHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateProviderHandler = updateProviderHandler;
            _updateProviderHandler.NotNull(nameof(updateProviderHandler));
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateProviderDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LineSection, LogLevelMessageResources.Provider + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateProviderDto updateProviderDto, CancellationToken cancellationToken)
        {
            await _updateProviderHandler.Handle(updateProviderDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(updateProviderDto);
        }
    }
}
