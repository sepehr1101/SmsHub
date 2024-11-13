using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Template.Querries
{
    [Route(nameof(TemplateCategory))]
    [ApiController]
    public class TemplateCategoryGetSingleController : ControllerBase
    {
        private readonly ITemplateCategoryGetSingleHandler _getSingleHandler;
        public TemplateCategoryGetSingleController(ITemplateCategoryGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetTemplateCategoryDto> GetSingle([FromBody] IntId Id)
        {
            var templateCategory = await _getSingleHandler.Handle(Id);
            return templateCategory;
        }
    }
}
