using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route("line")]
    [ApiController]
    public class UserLineGetByLineIdController:BaseController
    {
        private readonly IUserLineGetByLineIdHandler _userLineGetByLineIdHandler;
        public UserLineGetByLineIdController(IUserLineGetByLineIdHandler userLineGetByLineIdHandler)
        {
            _userLineGetByLineIdHandler = userLineGetByLineIdHandler;
            _userLineGetByLineIdHandler.NotNull(nameof(userLineGetByLineIdHandler));
        }

        [HttpPost]
        [Route("users/{lineId}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetUserLineByLineIdDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Users(int lineId,CancellationToken cancellationToken)
        {
            var result=await _userLineGetByLineIdHandler.Handle(lineId, cancellationToken);
            return Ok(result);
        }
    }
}
