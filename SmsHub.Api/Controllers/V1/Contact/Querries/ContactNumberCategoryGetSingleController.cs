using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(ContactNumberCategory))]
    [ApiController]
    [Authorize]
    public class ContactNumberCategoryGetSingleController : BaseController
    {
        private readonly IContactNumberCategoryGetSingleHandler _getSingleHandler;
        private readonly IUnitOfWork _uow;
        public ContactNumberCategoryGetSingleController(IContactNumberCategoryGetSingleHandler getSingleHandler,
            IUnitOfWork uow)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetContactNumberCategoryDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.ContactSection, LogLevelMessageResources.ContactNumberCategory + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id, CancellationToken cancellationToken)
        {
            var contactNumberCategory = await _getSingleHandler.Handle(Id);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(contactNumberCategory);
        }
    }
}
