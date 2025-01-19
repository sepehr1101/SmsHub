using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Security.Handlers.Commands.Delete.Contracts;
using SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Create
{
    [Route(nameof(UserLine))]
    [ApiController]
    public class UserLineCreateController : BaseController
    {
        private readonly IUserLineCreateHandler _userLineCreateHandler;
        private readonly IUserLineDeleteHandler _userLineDeleteHandler;
        private readonly IUserLineUpdateHandler _userLineUpdateHandler;
        private readonly IUserLineGetByLineIdHandler _userLineGetByLineIdHandler;
        private readonly IUserLineGetByUserIdHandler _userLineGetByUserIdHandler;
        private readonly IUnitOfWork _uow;

        public UserLineCreateController(
            IUserLineCreateHandler userLineCreateHandler,
            IUserLineDeleteHandler userLineDeleteHandler,
            IUserLineUpdateHandler userLineUpdateHandler,
            IUserLineGetByLineIdHandler userLineGetByLineIdHandler,
            IUserLineGetByUserIdHandler userLineGetByUserIdHandler,
            IUnitOfWork uow)
        {
            _userLineCreateHandler = userLineCreateHandler;
            _userLineCreateHandler.NotNull(nameof(userLineCreateHandler));

            _userLineDeleteHandler = userLineDeleteHandler;
            _userLineDeleteHandler.NotNull(nameof(userLineDeleteHandler));

            _userLineUpdateHandler = userLineUpdateHandler;
            _userLineUpdateHandler.NotNull(nameof(userLineUpdateHandler));

            _userLineGetByLineIdHandler = userLineGetByLineIdHandler;
            _userLineGetByLineIdHandler.NotNull(nameof(userLineGetByLineIdHandler));

            _userLineGetByUserIdHandler = userLineGetByUserIdHandler;
            _userLineGetByUserIdHandler.NotNull(nameof(_userLineGetByUserIdHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateUserLineDto userLineDto, CancellationToken cancellationToken)
        {
            await _userLineCreateHandler.Handle(userLineDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] DeleteUserLineDto userLineDto, CancellationToken cancellationToken)
        {
            await _userLineDeleteHandler.Handle(userLineDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok();
        }


        [HttpPost]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateUserLineDto userLineDto, CancellationToken cancellationToken)
        {
            await _userLineUpdateHandler.Handle(userLineDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok();
        }


        [HttpPost]
        [Route("GetByUserId/{userId})")]
        public async Task<IActionResult> GetByUserId(Guid userId, CancellationToken cancellationToken)
        {
            await _userLineGetByUserIdHandler.Handle(userId, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok();
        }


        [HttpPost]
        [Route("GetByLineId/{lineId})")]
        public async Task<IActionResult> GetByLineId(int lineId, CancellationToken cancellationToken)
        {
            await _userLineGetByLineIdHandler.Handle(lineId, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok();
        }
    }

}
