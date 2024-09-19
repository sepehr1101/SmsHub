namespace SmsHub.Common.Contrats
{
    public interface ISecurityOpertions
    {
        Task<string> GetSha512Hash(string input);
        Guid CreateCryptographicallySecureGuid();
        string EncryptAesGcm(string plain);
        string DecryptAesGcm(string plain);
    }
}
