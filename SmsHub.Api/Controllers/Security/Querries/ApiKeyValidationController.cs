using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;

namespace SmsHub.Api.Controllers.Security.Querries
{
    [Route(nameof(Security))]
    [ApiController]
    public class ApiKeyValidationController : ControllerBase//todo : true or not
    {
       private readonly IApiKeyValidationHandler _apiKeyValidationHandler;
        public ApiKeyValidationController(IApiKeyValidationHandler apiKeyValidationHandler)
        {
            _apiKeyValidationHandler = apiKeyValidationHandler;
            _apiKeyValidationHandler.NotNull(nameof(apiKeyValidationHandler));
        }

        [HttpPost]
        [Route(nameof(ApiKeyValidation))]
        public async Task<bool> ApiKeyValidation([FromBody]StringId apiKey)
        {
            var apiKeyValidation = await _apiKeyValidationHandler.Handle(apiKey);
            return apiKeyValidation;
        }
    }
}
