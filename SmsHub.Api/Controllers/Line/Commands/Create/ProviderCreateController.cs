using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Line.Commands.Create
{
    [Route(nameof(Provider))]
    [ApiController]
    public class ProviderCreateController : ControllerBase
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
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok("Done");
        }
    }
}
