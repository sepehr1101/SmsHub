﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(ContactNumber))]
    [ApiController]
    [Authorize]
    public class ContactNumberGetListController : BaseController
    {
        private readonly IContactNumberGetListHandler _getListHandler;
        private readonly IUnitOfWork _uow;
        public ContactNumberGetListController(IContactNumberGetListHandler getListHandler,
            IUnitOfWork uow)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetContactNumberDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.ContactSection, LogLevelMessageResources.ContactNumber + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var contactNumbers = await _getListHandler.Handle();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(contactNumbers);
        }
    }
}
