using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Contact.Commands.Update
{
    [Route(nameof(ContactNumber))]
    [ApiController]
    [Authorize]
    public class ContactNumberUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IContactNumberUpdateHandler _updateCommandHandler;
        private readonly IContactNumberCategoryGetSingleHandler _contactNumberCategoryGetSingleHandler;
        private readonly IContactCategoryGetSingleHandler _contactCategoryGetSingleHandler;

        public ContactNumberUpdateController(
            IUnitOfWork uow,
            IContactNumberUpdateHandler updateCommandHandler,
             IContactNumberCategoryGetSingleHandler contactNumberCategoryGetSingleHandler,
             IContactCategoryGetSingleHandler contactCategoryGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));

            _contactNumberCategoryGetSingleHandler = contactNumberCategoryGetSingleHandler;
            _contactNumberCategoryGetSingleHandler.NotNull(nameof(contactNumberCategoryGetSingleHandler));

            _contactCategoryGetSingleHandler = contactCategoryGetSingleHandler;
            _contactCategoryGetSingleHandler.NotNull(nameof(contactCategoryGetSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateContactNumberDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.ContactSection, LogLevelMessageResources.ContactNumber + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateContactNumberDto updateDto, CancellationToken cancellationToken)
        {

            IntId contactNumberCategoryId = updateDto.ContactNumberCategoryId;
            var contactNumberCategory = await _contactNumberCategoryGetSingleHandler.Handle(contactNumberCategoryId);

            IntId contactCategoryId = updateDto.ContactCategoryId;
            var contactCategory = await _contactCategoryGetSingleHandler.Handle(contactCategoryId);

            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(updateDto);
        }
    }
}
