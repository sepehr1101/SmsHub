using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Template.Commands.Delete
{
    [Route("template-category")]
    [ApiController]
    public class TemplateCategoryDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ITemplateCategoryDeleteHandler _deleteCommandHandler;
        public TemplateCategoryDeleteController(
            IUnitOfWork uow, 
            ITemplateCategoryDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }

        [HttpPost]
        [Route("delete")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteTemplateCategoryDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Delete([FromBody] DeleteTemplateCategoryDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
