﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Line.Commands.Create
{
    [Route(nameof(Provider))]
    [ApiController]
    public class ProviderCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IProviderCreateHandler _createCommandHandler;
        public ProviderCreateController(
            IUnitOfWork uow,
            IProviderCreateHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(_createCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateProviderDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            var db = _uow.GetDatabase();
            var con = db.GetConnectionString();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}