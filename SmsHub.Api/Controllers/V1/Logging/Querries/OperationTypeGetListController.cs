using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(OperationType))]
    [ApiController]
    [Authorize]
    public class OperationTypeGetListController : BaseController
    {
        private readonly IOperationTypeGetListHandler _getListHandler;
        private readonly IUnitOfWork _uow;
        public OperationTypeGetListController(
            IOperationTypeGetListHandler getListHandler, 
            IUnitOfWork uow)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetOperationTypeDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LoggingSection, LogLevelMessageResources.OpetationType + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var operationTypes = await _getListHandler.Handle();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(operationTypes);
        }
    }
}
