﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Consumer.Commands.Update
{
    [Route("api/Consumer")]
    [ApiController]
    public class ConsumerUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IUpdateConsumerHandler _updateCommandHandler;
        public ConsumerUpdateController(IUnitOfWork uow, IUpdateConsumerHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }
        [HttpGet(Name = nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateConsumerDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}