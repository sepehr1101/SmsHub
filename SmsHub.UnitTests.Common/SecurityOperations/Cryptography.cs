using SmsHub.Common.Contrats;

namespace SmsHub.UnitTests.Common.SecurityOperations
{
    public class Cryptography:IClassFixture<SecurityOperationsFixture>
    {
        private readonly ISecurityOperations _securityOperations;
        public Cryptography(SecurityOperationsFixture fixture)
        {
            _securityOperations=fixture.SecurityOperations;
        }

        [Fact]
        public void Crypto_CheckNumberString_ValidEncrypt()
        {
            string inputEncrypt= "1";
            var resultEncrypt = _securityOperations.EncryptAesGcm(inputEncrypt);

            var resultDecrypt=_securityOperations.DecryptAesGcm( resultEncrypt);
            Assert.Equal(inputEncrypt,resultDecrypt);
        }
        
        [Fact]
        public void Crypto_CheckStringWithUpperAndLowerAndCharacter_ValidEncrypt()
        {
            string inputEncrypt= "this Is SAMPLE text :)";
            var resultEncrypt = _securityOperations.EncryptAesGcm(inputEncrypt);

            var resultDecrypt=_securityOperations.DecryptAesGcm( resultEncrypt);
            Assert.Equal(inputEncrypt,resultDecrypt);
        }


        [Fact]
        public void Crypto_CheckMathString_ValidEncrypt()
        {
            string inputEncrypt = "log(8)2 + 7 = 10";
            var resultEncrypt = _securityOperations.EncryptAesGcm(inputEncrypt);

            var resultDecrypt = _securityOperations.DecryptAesGcm(resultEncrypt);
            Assert.Equal(inputEncrypt, resultDecrypt);
        }
        
        [Fact]
        public void Crypto_CheckPersianString_ValidEncrypt()
        {
            string inputEncrypt = "سَلام ! این یِک جُمله جَهت تست مِتُد اَست";
            var resultEncrypt = _securityOperations.EncryptAesGcm(inputEncrypt);

            var resultDecrypt = _securityOperations.DecryptAesGcm(resultEncrypt);
            Assert.Equal(inputEncrypt, resultDecrypt);
        }
        
        [Fact]
        public void Crypto_CheckPersianStringWithWithoutExclamationMark_ValidEncrypt()
        {
            string inputEncrypt = "سَلام  این یِک جُمله جَهت تست مِتُد اَست";
            var resultEncrypt = _securityOperations.EncryptAesGcm(inputEncrypt);

            var resultDecrypt = _securityOperations.DecryptAesGcm(resultEncrypt);
            Assert.Equal(inputEncrypt, resultDecrypt);
        }
    }
}
