using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Commands.Create
{
    [Route(nameof(DisallowedPhrase))]
    [ApiController]
    public class DisallowedPhraseCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IDisallowedPhraseCreateHandler _createCommandHandler;
        public DisallowedPhraseCreateController(IUnitOfWork uow, IDisallowedPhraseCreateHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateDisallowedPhraseDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }

}
