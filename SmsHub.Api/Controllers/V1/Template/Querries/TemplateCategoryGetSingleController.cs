﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Template.Querries
{
    [Route(nameof(TemplateCategory))]
    [ApiController]
    public class TemplateCategoryGetSingleController : BaseController
    {
        private readonly ITemplateCategoryGetSingleHandler _getSingleHandler;
        public TemplateCategoryGetSingleController(ITemplateCategoryGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var templateCategory = await _getSingleHandler.Handle(Id);
            return Ok(templateCategory);
        }
    }
}
