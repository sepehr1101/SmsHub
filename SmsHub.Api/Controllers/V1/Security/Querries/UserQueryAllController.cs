using Aban360.Api.Controllers.V1;
using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route("user")]
    [ApiController]
    [Authorize]
    public class UserQueryAllController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserGetAllHandler _userGetAllHandler;
        private readonly IUserGetByQuery _userGetByQuery;

        public UserQueryAllController(
            IUnitOfWork uow,
            IUserGetAllHandler userGetAllHandler,
            IUserGetByQuery userGetByQuery)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _userGetAllHandler = userGetAllHandler;
            _userGetAllHandler.NotNull(nameof(_userGetAllHandler));

            _userGetByQuery = userGetByQuery;
            _userGetByQuery.NotNull(nameof(_userGetByQuery));
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<UserQueryDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {            
            var userQueryDtos = await _userGetAllHandler.Handle(cancellationToken);
            return Ok(userQueryDtos);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("query")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<UserQueryDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsersByQuery([FromQuery] GridifyQuery query, CancellationToken cancellationToken)
        {
            var userQueryDtos = await _userGetByQuery.Handle(query, cancellationToken); ;
            return Ok(userQueryDtos);
        }
    }
}