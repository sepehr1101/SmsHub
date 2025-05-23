﻿using System.Net;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Application.Common.Constants;

namespace SmsHub.Api.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(
            HttpContext context, 
            IApiKeyValidationHandler apiKeyValidationHandler)
        {
            var plainTextApiKey = context.Request.Headers[HeaderKeys.ApiKeyHeaderName];
            if (plainTextApiKey.ToString() is null || plainTextApiKey=="")
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }
            if (!await apiKeyValidationHandler.Handle(plainTextApiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }
            await _next(context);
        }
    }
}