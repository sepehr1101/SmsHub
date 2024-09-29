using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Line.Commands.Create
{
    [Route("api/Provider")]
    [ApiController]
    public class ProviderCreateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ICreateProviderHandler _createCommandHandler;
        public ProviderCreateController(
            IUnitOfWork uow,
            ICreateProviderHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(_createCommandHandler));
        }

        [HttpGet(Name = nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateProviderDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            return Ok();
        }
    }
}
