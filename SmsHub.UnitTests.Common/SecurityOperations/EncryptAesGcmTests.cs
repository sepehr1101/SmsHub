using SmsHub.Common.Contrats;

namespace SmsHub.UnitTests.Common.SecurityOperations
{
    public class EncryptAesGcmTests:IClassFixture<SecurityOperationsFixture>
    {
        private readonly ISecurityOperations _securityOperations;
        public EncryptAesGcmTests(SecurityOperationsFixture fixture)
        {
            _securityOperations=fixture.SecurityOperations;
        }

        [Fact]
        public void EncryptAesGcm_CheckNumberString_ValidEncrypt()
        {
            string inputEncrypt= "1";
            var resultEncrypt = _securityOperations.EncryptAesGcm(inputEncrypt);

            var resultDecrypt=_securityOperations.DecryptAesGcm( inputEncrypt);
            Assert.Equal(inputEncrypt,resultDecrypt);
        }

    }
}
