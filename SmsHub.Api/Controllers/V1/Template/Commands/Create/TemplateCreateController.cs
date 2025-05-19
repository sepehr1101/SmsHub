using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Template.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Template.Commands.Create
{
    [Route("template")]
    [ApiController]
    [Authorize]
    public class TemplateCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ITemplateCreateHandler _createCommandHandler;
        private readonly ITemplateCategoryGetSingleHandler _templateCategoryGetSingleHandler;
        public TemplateCreateController(
            IUnitOfWork uow,
            ITemplateCreateHandler createCommandHandler,
            ITemplateCategoryGetSingleHandler templateCategoryGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));

            _templateCategoryGetSingleHandler = templateCategoryGetSingleHandler;
            _templateCategoryGetSingleHandler.NotNull(nameof(templateCategoryGetSingleHandler));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateTemplateDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.TemplateSection, LogLevelMessageResources.Template + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateTemplateDto createDto, CancellationToken cancellationToken)
        {
           var templateCategory = await _templateCategoryGetSingleHandler.Handle(createDto.TemplateCategoryId);
 
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
