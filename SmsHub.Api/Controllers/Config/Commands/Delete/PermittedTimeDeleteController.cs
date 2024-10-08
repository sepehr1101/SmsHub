using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Config.Commands.Delete
{
    [Route("api/PermittedTime")]
    [ApiController]
    public class PermittedTimeDeleteController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IPermittedTimeDeleteHandler _deleteCommandHandler;
        public PermittedTimeDeleteController(IUnitOfWork uow, IPermittedTimeDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }
        [HttpGet(Name = nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] DeletePermittedTimeDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(); 
        }
    }

}
