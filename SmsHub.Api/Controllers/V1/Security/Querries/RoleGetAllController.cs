using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;

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
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleGetAllHandler.Handle();
            return Ok(result);
        }
    }
}
