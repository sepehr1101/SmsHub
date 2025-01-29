using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Template.Querries
{
    [Route("template-category")]
    [ApiController]
    [Authorize]
    public class TemplateCategoryGetListController : BaseController
    {
        private readonly ITemplateCategoryGetListHandler _getListHandler;
        private readonly IUnitOfWork _uow;
        public TemplateCategoryGetListController(ITemplateCategoryGetListHandler getListHandler,
            IUnitOfWork uow)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route("alll")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.TemplateSection, LogLevelMessageResources.TemplateCategory + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var templateCategories = await _getListHandler.Handle();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(templateCategories);
        }
    }
}
