namespace SmsHub.Infrastructure.BaseHttp
{
    public static class KnownHeaders
    {
        public const string Authorization = "Authorization";
        public const string Accept = "Accept";
        public const string AcceptLanguage = "Accept-Language";
        public const string Allow = "Allow";
        public const string Expires = "Expires";
        public const string ContentDisposition = "Content-Disposition";
        public const string ContentEncoding = "Content-Encoding";
        public const string ContentLanguage = "Content-Language";
        public const string ContentLength = "Content-Length";
        public const string ContentLocation = "Content-Location";
        public const string ContentRange = "Content-Range";
        public const string ContentType = "Content-Type";
        public const string KeepAlive = "Keep-Alive";
        public const string LastModified = "Last-Modified";
        public const string ContentMD5 = "Content-MD5";
        public const string Host = "Host";
        public const string Cookie = "Cookie";
        public const string SetCookie = "Set-Cookie";
        public const string UserAgent = "User-Agent";
        
        internal static readonly string[] ContentHeaders = {
            Allow, Expires, ContentDisposition, ContentEncoding, ContentLanguage, ContentLength, ContentLocation, ContentRange, ContentType, ContentMD5,
            LastModified
        };

        static readonly HashSet<string> ContentHeadersHash = new(ContentHeaders, StringComparer.InvariantCultureIgnoreCase);

        internal static bool IsContentHeader(string key) => ContentHeadersHash.Contains(key);
    }
}
