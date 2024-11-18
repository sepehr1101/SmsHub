using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Line.Commands.Delete
{
    [Route(nameof(Provider))]
    [ApiController]
    public class ProviderDeleteController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IProviderDeleteHandler _providerDeleteHandler;
        public ProviderDeleteController(
            IUnitOfWork uow,
            IProviderDeleteHandler providerDeleteHandler)
        {
            _uow=uow;
            _uow.NotNull(nameof(uow));

            _providerDeleteHandler=providerDeleteHandler;
            _providerDeleteHandler.NotNull(nameof(providerDeleteHandler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] DeleteProviderDto deleteProviderDto, CancellationToken cancellationToken)
        {
            await _providerDeleteHandler.Handle(deleteProviderDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteProviderDto);
        }
    }
}
