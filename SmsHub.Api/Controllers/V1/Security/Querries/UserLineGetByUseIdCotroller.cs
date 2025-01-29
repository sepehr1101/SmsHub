using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route("user")]
    [ApiController]
    [Authorize]
    public class UserLineGetByUseIdCotroller:BaseController
    {
        private readonly IUserLineGetByUserIdHandler _userLineGetByUserIdHandler;
        private readonly IUnitOfWork _uow;
        public UserLineGetByUseIdCotroller(
            IUserLineGetByUserIdHandler userLineGetByUserIdHandler, 
            IUnitOfWork uow)
        {
            _userLineGetByUserIdHandler = userLineGetByUserIdHandler;
            _userLineGetByUserIdHandler.NotNull(nameof(userLineGetByUserIdHandler));

            _uow = uow;
            _uow.NotNull(nameof(_uow));
        }

        [HttpPost]
        [Route("lines/{userId}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetUserLineByUserIdDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.UserLine + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> Lines(Guid userId,CancellationToken cancellationToken)
        {
            var result=await _userLineGetByUserIdHandler.Handle(userId,cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(result);
        }
    }
}
