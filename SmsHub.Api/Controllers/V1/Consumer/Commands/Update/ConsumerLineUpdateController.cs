﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Consumer.Commands.Update
{
    [Route(nameof(ConsumerLine))]
    [ApiController]
    public class ConsumerLineUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IConsumerLineUpdateHandler _updateCommandHandler;
        public ConsumerLineUpdateController(
            IUnitOfWork uow,
            IConsumerLineUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateConsumerLineDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateConsumerLineDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
           return Ok(updateDto);
        }
    }
}
