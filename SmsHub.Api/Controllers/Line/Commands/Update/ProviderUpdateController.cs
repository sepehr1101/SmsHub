using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Line.Commands.Update
{
    [Route(nameof(Provider))]
    [ApiController]
    public class ProviderUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IProviderUpdateHandler _updateProviderHandler;
        public ProviderUpdateController(
            IUnitOfWork uow,
            IProviderUpdateHandler updateProviderHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateProviderHandler = updateProviderHandler;
            _updateProviderHandler.NotNull(nameof(updateProviderHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateProviderDto updateProviderDto, CancellationToken cancellationToken)
        {
            await _updateProviderHandler.Handle(updateProviderDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
