﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Template.Querries
{
    [Route(nameof(Template))]
    [ApiController]
    public class TemplateGetSingleController : ControllerBase
    {
        private readonly ITemplateGetSingleHandler _getSingleHandler;
        public TemplateGetSingleController(ITemplateGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetTemplateDto> GetSingle([FromBody] IntId Id)
        {
            var template = await _getSingleHandler.Handle(Id);
            return template;
        }
    }
}