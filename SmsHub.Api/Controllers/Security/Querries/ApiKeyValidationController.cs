using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Api.Controllers.Security.Querries
{
    [Route(nameof(Security))]
    [ApiController]
    public class ApiKeyValidationController : ControllerBase
    {
       private readonly IApiKeyValidationHandler _apiKeyValidationHandler;
        public ApiKeyValidationController(IApiKeyValidationHandler apiKeyValidationHandler)
        {
            _apiKeyValidationHandler = apiKeyValidationHandler;
            _apiKeyValidationHandler.NotNull(nameof(apiKeyValidationHandler));
        }

        [HttpPost]
        [Route(nameof(ApiKeyValidation))]
        public async Task<bool> ApiKeyValidation()
        {

        }
    }
}
