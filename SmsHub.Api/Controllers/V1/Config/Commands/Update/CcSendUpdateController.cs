using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Commands.Update
{
    [Route(nameof(CcSend))]
    [ApiController]
    public class CcSendUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ICcSendUpdateHandler _updateCommandHandler;
        public CcSendUpdateController(
            IUnitOfWork uow,
            ICcSendUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateCcSendDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Update([FromBody] UpdateCcSendDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(updateDto);
        }
    }
}
