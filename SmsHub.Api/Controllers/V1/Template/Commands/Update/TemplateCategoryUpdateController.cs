﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Template.Commands.Update
{
    [Route(nameof(TemplateCategory))]
    [ApiController]
    public class TemplateCategoryUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ITemplateCategoryUpdateHandler _updateCommandHandler;
        public TemplateCategoryUpdateController(
            IUnitOfWork uow,
            ITemplateCategoryUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateTemplateCategoryDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(updateDto);   
        }
    }
}
