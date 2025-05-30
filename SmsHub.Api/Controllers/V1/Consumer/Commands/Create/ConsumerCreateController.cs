﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Consumer.Commands.Create
{
    [Route(nameof(Consumer))]
    [ApiController]
    public class ConsumerCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IConsumerCreateHandler _createCommandHandler;
        public ConsumerCreateController(
            IUnitOfWork uow, 
            IConsumerCreateHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateConsumerDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateConsumerDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
