using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(OperationType))]
    [ApiController]
    public class OperationTypeGetListController : BaseController
    {
        private readonly IOperationTypeGetListHandler _getListHandler;
        public OperationTypeGetListController(IOperationTypeGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetOperationTypeDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList()
        {
            var operationTypes = await _getListHandler.Handle();
            return Ok(operationTypes);
        }
    }
}
