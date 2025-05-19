using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
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
    public class ServerUserGetByIdController : BaseController
    {
        private readonly IServerUserGetByIdHandler _getByIdHandler;
        private readonly IUnitOfWork _uow;
        public ServerUserGetByIdController(
            IServerUserGetByIdHandler getByIdHandler,
            IUnitOfWork uow)
        {
            _getByIdHandler = getByIdHandler;
            _getByIdHandler.NotNull(nameof(getByIdHandler));

            _uow = uow;
            _uow.NotNull(nameof(_uow));
        }

        [HttpPost]
        [Route(nameof(GetById))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetServerUserDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.ServerUser + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetById([FromBody] IntId Id, CancellationToken cancellationToken)
        {
            var serverUser = await _getByIdHandler.Handle(Id);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(serverUser);
        }
    }
}
