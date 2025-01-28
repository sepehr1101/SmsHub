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
    [Route("role")]
    [ApiController]
    [Authorize]
    public class RoleGetAllController:BaseController
    {
        private readonly IRoleGetAllHandler _roleGetAllHandler;
        private readonly IUnitOfWork _uow;

        public RoleGetAllController(
            IRoleGetAllHandler roleGetAllHandler,
            IUnitOfWork uow)
        {
            _roleGetAllHandler = roleGetAllHandler;
            _roleGetAllHandler.NotNull(nameof(roleGetAllHandler));

            _uow = uow;
            _uow.NotNull(nameof(_uow));
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetRoleDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.Role + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _roleGetAllHandler.Handle();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(result);
        }
    }
}
