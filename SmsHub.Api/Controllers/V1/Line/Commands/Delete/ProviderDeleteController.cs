using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Line.Commands.Delete
{
    [Route("provider")]
    [ApiController]
    [Authorize]
    public class ProviderDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IProviderDeleteHandler _providerDeleteHandler;
        public ProviderDeleteController(
            IUnitOfWork uow,
            IProviderDeleteHandler providerDeleteHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _providerDeleteHandler = providerDeleteHandler;
            _providerDeleteHandler.NotNull(nameof(providerDeleteHandler));
        }

        [HttpPost]
        [Route("delete")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteProviderDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LineSection, LogLevelMessageResources.Provider + LogLevelMessageResources.DeleteDescription)]
        public async Task<IActionResult> Delete([FromBody] DeleteProviderDto deleteProviderDto, CancellationToken cancellationToken)
        {
            return ClientError("ای بخش در دسترس نمی‌باشد");

            await _providerDeleteHandler.Handle(deleteProviderDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteProviderDto);
        }
    }
}
