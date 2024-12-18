﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route(nameof(Config))]
    [ApiController]
    public class ConfigGetSingleController : BaseController
    {
        private readonly IConfigGetSingleHandler _getSingleHandler;
        public ConfigGetSingleController(IConfigGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var config = await _getSingleHandler.Handle(Id);
            return Ok(config);
        }
    }
}
