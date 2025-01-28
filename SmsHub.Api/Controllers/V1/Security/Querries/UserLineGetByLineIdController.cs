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
    [Route("line")]
    [ApiController]
    [Authorize]
    public class UserLineGetByLineIdController:BaseController
    {
        private readonly IUserLineGetByLineIdHandler _userLineGetByLineIdHandler;
        private readonly IUnitOfWork _uow;
        public UserLineGetByLineIdController(
            IUserLineGetByLineIdHandler userLineGetByLineIdHandler,
            IUnitOfWork uow)
        {
            _userLineGetByLineIdHandler = userLineGetByLineIdHandler;
            _userLineGetByLineIdHandler.NotNull(nameof(userLineGetByLineIdHandler));

            _uow = uow;
            _uow.NotNull(nameof(_uow));
        }

        [HttpPost]
        [Route("users/{lineId}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetUserLineByLineIdDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.UserLine + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> Users(int lineId,CancellationToken cancellationToken)
        {
            var result=await _userLineGetByLineIdHandler.Handle(lineId, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(result);
        }
    }
}
