﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Logging.Querries
{
    [Route(nameof(LogLevel))]
    [ApiController]
    public class LogLevelGetSingleController : ControllerBase
    {
        private readonly ILogLevelGetSingleHandler _getSingleHandler;
        public LogLevelGetSingleController(ILogLevelGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetLogLevelDto> GetSingle([FromBody] IntId Id)
        {
            var logLevel = await _getSingleHandler.Handle(Id);
            return logLevel;
        }
    }
}