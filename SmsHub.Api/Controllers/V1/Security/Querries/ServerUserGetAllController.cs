using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route(nameof(Security))]
    [ApiController]
    public class ServerUserGetAllController : ControllerBase
    {
        private readonly IServerUserGetAllHandler _getAllHandler;
        public ServerUserGetAllController(IServerUserGetAllHandler getAllHandler)
        {
            _getAllHandler = getAllHandler;
            _getAllHandler.NotNull(nameof(getAllHandler));
        }

        [HttpPost]
        [Route(nameof(GetAll))]
        public async Task<ICollection<GetServerUserDto>> GetAll()
        {
            var serverUsers = await _getAllHandler.Handle();
            return serverUsers;
        }
    }
}
