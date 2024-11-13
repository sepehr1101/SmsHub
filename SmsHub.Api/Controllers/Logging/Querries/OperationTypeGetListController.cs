using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Logging.Querries
{
    [Route(nameof(OperationType))]
    [ApiController]
    public class OperationTypeGetListController : ControllerBase
    {
        private readonly IOperationTypeGetListHandler _getListHandler;
        public OperationTypeGetListController(IOperationTypeGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetOperationTypeDto>> GetList()
        {
            var operationTypes = await _getListHandler.Handle();
            return operationTypes;
        }
    }
}
