using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Logging.Commands.Delete
{
    [Route("api/InformativeLog")]
    [ApiController]
    public class InformativeLogDeleteController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IInformativeLogDeleteHandler _deleteCommandHandler;
        public InformativeLogDeleteController(IUnitOfWork uow, IInformativeLogDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }
        [HttpGet(Name = nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] DeleteInformativeLogDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
