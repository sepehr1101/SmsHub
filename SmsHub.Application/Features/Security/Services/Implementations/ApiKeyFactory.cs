using SmsHub.Application.Features.Security.Services.Contracts;
using SmsHub.Common.Contrats;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using System.Text;

namespace SmsHub.Application.Features.Security.Services.Implementations
{
    public class ApiKeyFactory : IApiKeyFactory
    {
        private readonly ISecurityOpertions _securityOperaions;
        public ApiKeyFactory(ISecurityOpertions securityOpertions)
        {
            _securityOperaions = securityOpertions;
            _securityOperaions.NotNull(nameof(_securityOperaions));
        }
        public async Task<ApiKeyAndHash> Create()
        {
            var guid = _securityOperaions.CreateCryptographicallySecureGuid();
            StringBuilder sb = new StringBuilder();
            sb.Append(guid).Replace("-", string.Empty).ToString();
            var apiKey = sb.ToString();
            var hashedValue = await _securityOperaions.GetSha512Hash(apiKey);
            return new ApiKeyAndHash(apiKey, hashedValue);
        }
    }
}
