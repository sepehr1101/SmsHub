using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route(nameof(ServerUser))]
    [ApiController]
    [Authorize]
    public class ServerUserGetAllController : BaseController
    {
        private readonly IServerUserGetAllHandler _getAllHandler; 
        private readonly IUnitOfWork _uow;
        public ServerUserGetAllController(
            IServerUserGetAllHandler getAllHandler,
            IUnitOfWork uow)
        {
            _getAllHandler = getAllHandler;
            _getAllHandler.NotNull(nameof(getAllHandler));

            _uow = uow;
            _uow.NotNull(nameof(_uow));
        }

        [HttpPost]
        [Route(nameof(GetAll))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetServerUserDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.ServerUser + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var serverUsers = await _getAllHandler.Handle(); 
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(serverUsers);
        }
    }
}
