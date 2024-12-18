﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route(nameof(ServerUser))]
    [ApiController]
    public class ServerUserGetByApiKeyController : BaseController
    {
        private readonly IServerUserGetByApiKeyHandler _getByApiKeyHandler;
        public ServerUserGetByApiKeyController(IServerUserGetByApiKeyHandler getByApiKeyHandler)
        {
            _getByApiKeyHandler = getByApiKeyHandler;
            _getByApiKeyHandler.NotNull(nameof(getByApiKeyHandler));
        }

        [HttpPost]
        [Route(nameof(GetByApiKey))]
        public async Task<IActionResult> GetByApiKey([FromBody] StringId apiKey)
        {
            var serverUser = await _getByApiKeyHandler.Handle(apiKey);
            return Ok(serverUser);
        }
    }
}
