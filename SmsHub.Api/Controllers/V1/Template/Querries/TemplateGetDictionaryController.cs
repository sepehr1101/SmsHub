using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;

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
        public async Task<IActionResult> Dictionary()
        {
            var result = await _templateGetAllDictionaryHandler.Handle();

            return Ok(result);
        }
    }
}
