using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(OperationType))]
    [ApiController]
    public class OperationTypeGetSingleController : ControllerBase
    {
        private readonly IOperationTypeGetSingleHandler _getSingleHandler;
        public OperationTypeGetSingleController(IOperationTypeGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetOperationTypeDto> GetSingle([FromBody] IntId Id)
        {
            var operationType = await _getSingleHandler.Handle(Id);
            return operationType;
        }
    }
}
