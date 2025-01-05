using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SmsHub.Application.Features.Security.Services.Contracts
{
    public interface ITokenValidatorService
    {
        Task ValidateAsync(TokenValidatedContext context);
    }
}