using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route("user")]
    [ApiController]
    public class UserLineGetByUseIdCotroller:BaseController
    {
        private readonly IUserLineGetByUserIdHandler _userLineGetByUserIdHandler;
        public UserLineGetByUseIdCotroller(IUserLineGetByUserIdHandler userLineGetByUserIdHandler)
        {
            _userLineGetByUserIdHandler = userLineGetByUserIdHandler;
            _userLineGetByUserIdHandler.NotNull(nameof(userLineGetByUserIdHandler));
        }

        [HttpPost]
        [Route("lines/{userId}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetUserLineByUserIdDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Lines(Guid userId,CancellationToken cancellationToken)
        {
            var result=await _userLineGetByUserIdHandler.Handle(userId,cancellationToken);
            return Ok(result);
        }
    }
}
