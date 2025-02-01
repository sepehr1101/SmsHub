using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Auth.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Create
{
    [Route("user")]
    [Authorize]
    public class UserCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserCreateHandler _createUserHandler;
        private readonly ICheckRoleByCollectionIdHandler _checkRoleByCollectionIdHandler;
        public UserCreateController(
            IUnitOfWork uow,
            IUserCreateHandler userCreateHandler,
            ICheckRoleByCollectionIdHandler checkRoleByCollectionIdHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _createUserHandler = userCreateHandler;
            _createUserHandler.NotNull(nameof(_createUserHandler));

            _checkRoleByCollectionIdHandler=checkRoleByCollectionIdHandler;
            _checkRoleByCollectionIdHandler.NotNull(nameof(_checkRoleByCollectionIdHandler));
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UserCreateDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.User + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> CreateUser([FromBody]UserCreateDto userCreateDto, CancellationToken cancellationToken)
        {
            var roleCount = await _checkRoleByCollectionIdHandler.Handle(userCreateDto.RoleIds);
            if (roleCount != userCreateDto.RoleIds.Count)
                throw new InvalidForeignKeyException(nameof(Role));

            await _createUserHandler.Handle(userCreateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(userCreateDto);
        }

        [Route("test")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Test()
        {
            throw new InvalidLineException();
        }
    }
}
