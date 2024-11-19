using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route(nameof(Security))]
    [ApiController]
    public class ServerUserGetAllController : BaseController
    {
        private readonly IServerUserGetAllHandler _getAllHandler;
        public ServerUserGetAllController(IServerUserGetAllHandler getAllHandler)
        {
            _getAllHandler = getAllHandler;
            _getAllHandler.NotNull(nameof(getAllHandler));
        }

        [HttpPost]
        [Route(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var serverUsers = await _getAllHandler.Handle();
            return Ok(serverUsers);
        }
    }
}
