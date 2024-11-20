using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Template.Querries
{
    [Route(nameof(TemplateCategory))]
    [ApiController]
    public class TemplateCategoryGetListController : BaseController
    {
        private readonly ITemplateCategoryGetListHandler _getListHandler;
        public TemplateCategoryGetListController(ITemplateCategoryGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var templateCategories = await _getListHandler.Handle();
            return Ok(templateCategories);
        }
    }
}
