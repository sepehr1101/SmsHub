using Microsoft.AspNetCore.Authentication.JwtBearer;
using SmsHub.Application.Features.Security.Services.Contracts;

namespace SmsHub.Application.Features.Security.Services.Implementations
{
    public class TokenValidatorService : ITokenValidatorService
    {
        public Task ValidateAsync(TokenValidatedContext context)
        {           
            return Task.FromResult(0);
        }
    }
}
