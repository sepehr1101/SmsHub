using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Contact.Commands.Update
{
    [Route(nameof(Contact))]
    [ApiController]
    [Authorize]
    public class ContactUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IContactUpdateHandler _updateCommandHandler;
        public ContactUpdateController(
            IUnitOfWork uow,
            IContactUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateContactDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.ContactSection, LogLevelMessageResources.Contact + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateContactDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
           return Ok(updateDto);
        }
    }
}
