using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Create
{
    [Route(nameof(ServerUser))]
    [ApiController]
    [Authorize]
    public class ServerUserCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IServerUserCreateHandler _createServerUserHandler;
        public ServerUserCreateController(
            IUnitOfWork uow,
            IServerUserCreateHandler createServerUserHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createServerUserHandler = createServerUserHandler;
            _createServerUserHandler.NotNull(nameof(createServerUserHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ApiKeyAndHash>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.ServerUser + LogLevelMessageResources.AddDescription)]
       //what is userId , fullname
        public async Task<IActionResult> Create([FromBody] CreateServerUserDto dto, CancellationToken cancellationToken)
        {
            var apiKeyAndHash = await _createServerUserHandler.Handle(dto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(apiKeyAndHash);
        }
    }
}
