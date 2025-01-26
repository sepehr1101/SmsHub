using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Template.Querries
{
    [Route("template")]
    [ApiController]
    public class TemplateGetDictionaryController:BaseController
    {
        private readonly ITemplateGetAllDictionaryHandler _templateGetAllDictionaryHandler;
        public TemplateGetDictionaryController(ITemplateGetAllDictionaryHandler templateGetAllDictionaryHandler)
        {
            _templateGetAllDictionaryHandler=templateGetAllDictionaryHandler;
            _templateGetAllDictionaryHandler.NotNull(nameof(templateGetAllDictionaryHandler));
        }

        [HttpGet]
        [Route("dictionary")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<TemplateDictionary>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Dictionary()
        {
            var result = await _templateGetAllDictionaryHandler.Handle();

            return Ok(result);
        }
    }
}
