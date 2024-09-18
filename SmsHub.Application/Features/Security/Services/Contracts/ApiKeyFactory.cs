using SmsHub.Application.Features.Security.Services.Implementations;
using SmsHub.Common;
using SmsHub.Domain.Features.Security.Dtos;
using System.Text;

namespace SmsHub.Application.Features.Security.Services.Contracts
{
    internal class ApiKeyFactory : IApiKeyFactory
    {
        private readonly ISecurityOpertions _securityOperaions;
        public ApiKeyFactory(ISecurityOpertions securityOpertions)
        {
            _securityOperaions = securityOpertions;
            _securityOperaions.NotNull(nameof(_securityOperaions));
        }
        public async Task<ApiKeyAndHash> Create()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            StringBuilder sb = new StringBuilder();
            sb.Append(guid1).Append(guid2).Replace("-", string.Empty).ToString();
            var apiKey = sb.ToString();
            var hashedValue = await _securityOperaions.GetSha512Hash(apiKey);
            return new ApiKeyAndHash(apiKey, hashedValue);
        }
    }
}
