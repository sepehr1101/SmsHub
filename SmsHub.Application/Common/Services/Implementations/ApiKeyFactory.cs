using SmsHub.Application.Common.Services.Contracts;
using SmsHub.Common.Contrats;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using System.Text;

namespace SmsHub.Application.Common.Services.Implementations
{
    public class ApiKeyFactory : IApiKeyFactory
    {
        private readonly ISecurityOpertions _securityOperaions;
        public ApiKeyFactory(ISecurityOpertions securityOpertions)
        {
            _securityOperaions = securityOpertions;
            _securityOperaions.NotNull(nameof(_securityOperaions));
        }
        public async Task<ApiKeyAndHash> Create(string username)
        {
            var base64Username = _securityOperaions.Base64Encode(username);
            var guid = _securityOperaions.CreateCryptographicallySecureGuid();
            StringBuilder sb = new StringBuilder();
            var apiKey= sb.Append(guid).Replace("-", string.Empty).Append(".").Append(base64Username).ToString();
            var hashedValue = await _securityOperaions.GetSha512Hash(apiKey);           
            return new ApiKeyAndHash(apiKey, hashedValue);
        }
    }
}
