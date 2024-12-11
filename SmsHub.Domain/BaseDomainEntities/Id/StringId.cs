using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;

namespace SmsHub.Domain.BaseDomainEntities.Id
{
    public record StringId
    {
        public string ApiKey { get; private set; }
        public StringId(string apiKey)
        {
            apiKey.NotEmptyString(nameof(apiKey));

            ApiKey = apiKey;
            
        }

        public static implicit operator StringId(string apiKey)=>new StringId(apiKey);
    }
}
