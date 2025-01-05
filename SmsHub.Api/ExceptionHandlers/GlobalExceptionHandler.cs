using Microsoft.AspNetCore.Diagnostics;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using System.Net;

namespace SmsHub.Api.ExceptionHandlers
{
    internal sealed class GlobalExceptionHandler : IExceptionHandler
    {
        //private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            //_logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var message = $"Exception occurred: Message: {exception.Message}, Inner Exception:{exception.InnerException.Message}";
            //_logger.LogError(
            //    exception, "Exception occurred: {Message}", exception.Message);

            var problemDetails = new ApiResponseEnvelope<string>((int)HttpStatusCode.InternalServerError, message, null, new[] { new ApiError(message, (int)HttpStatusCode.InternalServerError) });

            httpContext.Response.StatusCode = problemDetails.HttpStatusCode;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
