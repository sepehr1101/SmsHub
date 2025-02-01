using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Template.Handlers.Queries.Implementations;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
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

        private readonly ITemplateCategoryGetSingleHandler _templateCategoryGetSingleHandler;




        public TemplateUpdateController(
            IUnitOfWork uow,
            ITemplateUpdateHandler updateCommandHandler,
            ITemplateCategoryGetSingleHandler templateCategoryGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));

            _templateCategoryGetSingleHandler = templateCategoryGetSingleHandler;
            _templateCategoryGetSingleHandler.NotNull(nameof(templateCategoryGetSingleHandler));
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateTemplateDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.TemplateSection, LogLevelMessageResources.Template + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateTemplateDto updateDto, CancellationToken cancellationToken)
        {
            var templateCategory = await _templateCategoryGetSingleHandler.Handle(updateDto.TemplateCategoryId);

            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(updateDto);
        }
    }
}
