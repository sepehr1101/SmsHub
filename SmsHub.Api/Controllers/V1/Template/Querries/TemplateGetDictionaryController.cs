using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Template.Querries
{
    [Route("template")]
    [ApiController]
    [Authorize]
    public class TemplateGetDictionaryController:BaseController
    {
        private readonly ITemplateGetDictionaryByTemplateCategoryIdHandler _templateGetAllDictionaryHandler;
        private readonly IUnitOfWork _uow;
        public TemplateGetDictionaryController(ITemplateGetDictionaryByTemplateCategoryIdHandler templateGetAllDictionaryHandler,
            IUnitOfWork uow)
        {
            _templateGetAllDictionaryHandler=templateGetAllDictionaryHandler;
            _templateGetAllDictionaryHandler.NotNull(nameof(templateGetAllDictionaryHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route("dictionary/{templateCategoryId}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<TemplateDictionary>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.TemplateSection, LogLevelMessageResources.TemplateCategory + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> Dictionary(IntId templateCategoryId, CancellationToken cancellationToken)
        {
            var result = await _templateGetAllDictionaryHandler.Handle(templateCategoryId);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(result);
        }
    }
}
