using Microsoft.AspNetCore.Authentication.JwtBearer;
using SmsHub.Application.Features.Security.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
