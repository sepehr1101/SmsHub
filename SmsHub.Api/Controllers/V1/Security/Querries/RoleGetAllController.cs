using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route("role")]
    [ApiController]
    public class RoleGetAllController:BaseController
    {
        private readonly IRoleGetAllHandler _roleGetAllHandler;
        public RoleGetAllController(IRoleGetAllHandler roleGetAllHandler)
        {
            _roleGetAllHandler = roleGetAllHandler;
            _roleGetAllHandler.NotNull(nameof(roleGetAllHandler));
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetRoleDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAll()
        {
            var result = await _roleGetAllHandler.Handle();
            return Ok(result);
        }
    }
}
