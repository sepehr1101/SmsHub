using Newtonsoft.Json;
using SmsHub.Application.Exceptions;
using MagfaCredentialDto = SmsHub.Domain.Providers.Magfa3000.Entities.Responses.CredentialDto;
using KavenegarCredentialDto = SmsHub.Domain.Providers.Kavenegar.Entities.Responses.CredentialDto;


namespace SmsHub.Application.Common.Services.Implementations
{
    public static class ProviderCredentialService
    {
        public static KavenegarCredentialDto CheckKavenegarValidCredential(string credential)
        {
            var resultKavenegarDeserialize = DeserializeCredential<KavenegarCredentialDto>(credential);
            if (resultKavenegarDeserialize != null)
            {
                if (string.IsNullOrWhiteSpace(resultKavenegarDeserialize.apiKey))
                    throw new ProviderCredentialException("کاوه نگار");
            }
            else
            {
                throw new ProviderCredentialException("کاوه نگار");
            }
            return resultKavenegarDeserialize;
        }
        public static T DeserializeCredential<T>(string credential)
        {
            T resultDeserialize;
            try
            {
                resultDeserialize = JsonConvert.DeserializeObject<T>(credential);
            }
            catch
            {
                throw new ProviderCredentialException("");
            }

            return resultDeserialize;
        }
    }
}
