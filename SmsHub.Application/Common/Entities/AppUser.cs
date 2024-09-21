using Microsoft.AspNetCore.Http;
using SmsHub.Application.Common.Constants;
using SmsHub.Common.Contrats;
using SmsHub.Common.Extensions;

namespace SmsHub.Application.Common.Entities
{
    internal class AppUser
    {
        private string _hashedApiKey = null!;
        private ISecurityOpertions _securityOpertions;
        private IHttpContextAccessor _httpContext; 
        public AppUser(ISecurityOpertions securityOpertions, IHttpContextAccessor httpContext)
        {
            _securityOpertions = securityOpertions;
            _securityOpertions.NotNull(nameof(securityOpertions));

            _httpContext = httpContext;
            _httpContext.NotNull(nameof(httpContext));

            _hashedApiKey = _httpContext.HttpContext.Request.Headers[HeaderKeys.ApiKeyHeaderName].ToString();
            _hashedApiKey.NotNull(nameof(_hashedApiKey));
        }

        internal string Name
        {
            get
            {
               var splited= _hashedApiKey.Split(".");
                var base64decoded = _securityOpertions.Base64Decode(splited[1]);
                return base64decoded;
            }
        }
    }
}
