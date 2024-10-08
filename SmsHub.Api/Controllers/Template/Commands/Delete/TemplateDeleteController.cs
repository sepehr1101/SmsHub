using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Template.Commands.Delete
{
    [Route("api/Template")]
    [ApiController]
    public class TemplateDeleteController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ITemplateDeleteHandler _deleteCommandHandler;
        public TemplateDeleteController(IUnitOfWork uow, ITemplateDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }
        [HttpGet(Name = nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] DeleteTemplateDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
