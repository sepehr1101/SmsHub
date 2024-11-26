using Newtonsoft.Json;

namespace SmsHub.Application.Features.Line.Validations
{
    public class MagfaCredentialValidator
    {
        private class MagfaCredntial
        {
            public string Domain { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public bool Validate(string credential)
        {
            try
            {
                var toBeCheckedCredential = JsonConvert.DeserializeObject<MagfaCredntial>(credential);
                if(toBeCheckedCredential is null)
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(toBeCheckedCredential.Domain))
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(toBeCheckedCredential.Username))
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(toBeCheckedCredential.Password))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
