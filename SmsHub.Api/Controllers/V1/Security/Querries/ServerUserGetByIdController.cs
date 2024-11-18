using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Security.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route(nameof(Security))]
    [ApiController]
    public class ServerUserGetByIdController : BaseController
    {
        private readonly IServerUserGetByIdHandler _getByIdHandler;
        public ServerUserGetByIdController(IServerUserGetByIdHandler getByIdHandler)
        {
            _getByIdHandler = getByIdHandler;
            _getByIdHandler.NotNull(nameof(getByIdHandler));
        }

        [HttpPost]
        [Route(nameof(GetById))]
        public async Task<GetServerUserDto> GetById([FromBody] IntId Id)
        {
            var serverUser = await _getByIdHandler.Handle(Id);
            return serverUser;
        }
    }
}
