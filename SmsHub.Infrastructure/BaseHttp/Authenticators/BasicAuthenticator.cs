using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;

namespace SmsHub.Infrastructure.BaseHttp.Authenticators
{
    public static partial class Authenticator
    {
        public static HttpRequestMessage AddBasicAuthentication(this HttpRequestMessage requestMessage, string clientId, string clientSecret, [Optional] Encoding encoding)
        {
            encoding = encoding ?? Encoding.ASCII;
            var authenticationString = $"{clientId}:{clientSecret}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(encoding.GetBytes(authenticationString));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
            return requestMessage;
        }
    }
}
