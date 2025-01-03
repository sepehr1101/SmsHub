﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(LogLevel))]
    [ApiController]
    public class LogLevelGetListController : BaseController
    {
        private readonly ILogLevelGetListHandler _getListHandler;
        public LogLevelGetListController(ILogLevelGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var logLevels = await _getListHandler.Handle();
            return Ok(logLevels);
        }
    }
}
