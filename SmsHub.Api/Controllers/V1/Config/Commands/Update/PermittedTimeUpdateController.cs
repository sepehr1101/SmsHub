using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Commands.Update
{
    [Route(nameof(PermittedTime))]
    [ApiController]
    public class PermittedTimeUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IPermittedTimeUpdateHandler _updateCommandHandler;
        public PermittedTimeUpdateController(
            IUnitOfWork uow,
            IPermittedTimeUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }

        [HttpPost]
        [HttpPost(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdatePermittedTimeDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
           return Ok(updateDto);
        }
    }
}
