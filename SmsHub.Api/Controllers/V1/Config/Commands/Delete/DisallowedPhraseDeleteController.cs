using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Commands.Delete
{
    [Route(nameof(DisallowedPhrase))]
    [ApiController]
    public class DisallowedPhraseDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IDisallowedPhraseDeleteHandler _deleteCommandHandler;
        public DisallowedPhraseDeleteController(IUnitOfWork uow, IDisallowedPhraseDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] DeleteDisallowedPhraseDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
