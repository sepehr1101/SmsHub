﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Config.Commands.Update
{
    [Route("api/DisallowedPhrase")]
    [ApiController]
    public class DisallowedPhraseUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IUpdateDisallowedPhraseHandler _updateCommandHandler;
        public DisallowedPhraseUpdateController(IUnitOfWork uow, IUpdateDisallowedPhraseHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }
        [HttpGet(Name = nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateDisallowedPhraseDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}