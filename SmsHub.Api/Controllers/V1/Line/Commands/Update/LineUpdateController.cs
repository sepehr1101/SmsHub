using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Line.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Line.Commands.Update
{
    [Route("line")]
    [ApiController]
    [Authorize]
    public class LineUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ILineUpdateHandler _updateCommandHandler;
        private readonly IProviderGetSingleHandler _providerGetSingleHandler;
        public LineUpdateController(
            IUnitOfWork uow,
            ILineUpdateHandler updateCommandHandler,
            IProviderGetSingleHandler providerGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));

            _providerGetSingleHandler = providerGetSingleHandler;
            _providerGetSingleHandler.NotNull(nameof(_providerGetSingleHandler));
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateLineDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LineSection, LogLevelMessageResources.Line + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateLineDto updateDto, CancellationToken cancellationToken)
        {
            var provider = await _providerGetSingleHandler.Handle(updateDto.ProviderId);

            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(updateDto);
        }
    }
}
