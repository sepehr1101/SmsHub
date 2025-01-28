using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Template.Commands.Update
{
    [Route("template")]
    [ApiController]
    [Authorize]
    public class TemplateUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ITemplateUpdateHandler _updateCommandHandler;
        public TemplateUpdateController(
            IUnitOfWork uow, 
            ITemplateUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateTemplateDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.TemplateSection, LogLevelMessageResources.Template + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateTemplateDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
           return Ok(updateDto);
        }
    }
}
