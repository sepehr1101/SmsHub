using SmsHub.Common.Contrats;

namespace SmsHub.UnitTests.Common.SecurityOperations
{
    public class CreateCryptographicallySecureGuidTests:IClassFixture<SecurityOperationsFixture>
    {
        private readonly ISecurityOperations _securityOperations;
        public CreateCryptographicallySecureGuidTests(SecurityOperationsFixture fixture)
        {
            _securityOperations=fixture.SecurityOperations;
        }
        [Fact]
        public void CreateCryptographicallySecureGuid_CheckTrue_ValidGuid()
        {
            var result=_securityOperations.CreateCryptographicallySecureGuid();
            Assert.True(true);
        }
    }
}
