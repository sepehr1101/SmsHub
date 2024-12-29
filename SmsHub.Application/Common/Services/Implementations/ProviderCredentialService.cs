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
                    throw new ProviderCredentialByInvalidPropertyException(ExceptionLiterals.Kavenegar, ExceptionLiterals.ApiKey);
            }
            else
            {
                throw new ProviderCredentialByNullPropertyException(ExceptionLiterals.Kavenegar);
            }
            return resultKavenegarDeserialize;
        }

        public static MagfaCredentialDto CheckMagfaValidCredential(string credential)
        {
            var resultMagfaDeserialize = DeserializeCredential<MagfaCredentialDto>(credential);
            if (resultMagfaDeserialize != null)
            {
                if (string.IsNullOrWhiteSpace(resultMagfaDeserialize.ClientSecret))
                    throw new ProviderCredentialByInvalidPropertyException(ExceptionLiterals.Magfa, ExceptionLiterals.ClientSecret);

                 if (string.IsNullOrWhiteSpace(resultMagfaDeserialize.UserName))
                    throw new ProviderCredentialByInvalidPropertyException(ExceptionLiterals.Magfa, ExceptionLiterals.UserName);

                 if (string.IsNullOrWhiteSpace(resultMagfaDeserialize.Domain))
                    throw new ProviderCredentialByInvalidPropertyException(ExceptionLiterals.Magfa, ExceptionLiterals.Domain);
            }
            else
            {
                throw new ProviderCredentialByNullPropertyException(ExceptionLiterals.Magfa);
            }

            return resultMagfaDeserialize;

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
                throw new ProviderCredentialException();
            }

            return resultDeserialize;
        }
    }
}
