using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Update
{
    [Route("user")]
    [Authorize]
    public class UserUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserUpdateHandler _userUpdateHandler;
        private readonly ICheckRoleByCollectionIdHandler _checkRoleByCollectionIdHandler;
        public UserUpdateController(
            IUnitOfWork uow,
            IUserUpdateHandler userUpdateHandler,
            ICheckRoleByCollectionIdHandler checkRoleByCollectionIdHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userUpdateHandler = userUpdateHandler;
            _userUpdateHandler.NotNull(nameof(userUpdateHandler));

            _checkRoleByCollectionIdHandler = checkRoleByCollectionIdHandler;
            _checkRoleByCollectionIdHandler.NotNull(nameof(_checkRoleByCollectionIdHandler));
        }

        [HttpPost, HttpPatch]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UserUpdateDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.User + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userUpdateDto, CancellationToken cancellationToken)
        {

            var roleCount = await _checkRoleByCollectionIdHandler.Handle(userUpdateDto.RoleIds);
            if (roleCount != userUpdateDto.RoleIds.Count)
                throw new InvalidForeignKeyException(nameof(Role));

            await _userUpdateHandler.Handle(userUpdateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(userUpdateDto);
        }
    }
}