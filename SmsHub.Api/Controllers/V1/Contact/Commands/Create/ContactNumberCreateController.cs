using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Contact.Commands.Create
{
    [Route(nameof(ContactNumber))]
    [ApiController]
    [Authorize]
    public class ContactNumberCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IContactNumberCreateHandler _createCommandHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;
        private readonly IContactNumberCategoryGetSingleHandler _contactNumberCategoryGetSingleHandler;
        private readonly IContactCategoryGetSingleHandler _contactCategoryGetSingleHandler;
        public ContactNumberCreateController(
            IUnitOfWork uow, 
            IContactNumberCreateHandler createCommandHandler,
            IInformativeLogCreateHandler informativeLogCreateHandler,
            IContactNumberCategoryGetSingleHandler contactNumberCategoryGetSingleHandler,
            IContactCategoryGetSingleHandler contactCategoryGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));

            _contactNumberCategoryGetSingleHandler = contactNumberCategoryGetSingleHandler;
            _contactNumberCategoryGetSingleHandler.NotNull(nameof(contactNumberCategoryGetSingleHandler));

            _contactCategoryGetSingleHandler = contactCategoryGetSingleHandler;
            _contactCategoryGetSingleHandler.NotNull(nameof(contactCategoryGetSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateContactNumberDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.ContactSection, LogLevelMessageResources.ContactNumber + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateContactNumberDto createDto, CancellationToken cancellationToken)
        {
            IntId contactNumberCategoryId = createDto.ContactNumberCategoryId;
            var contactNumberCategory = await _contactNumberCategoryGetSingleHandler.Handle(contactNumberCategoryId);

            IntId contactCategoryId = createDto.ContactCategoryId;
            var contactCategory = await _contactCategoryGetSingleHandler.Handle(contactCategoryId);

            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
