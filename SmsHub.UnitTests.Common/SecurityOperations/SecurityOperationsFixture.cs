using SmsHub.Common.Contrats;

namespace SmsHub.UnitTests.Common.SecurityOperations
{
    public class SecurityOperationsFixture : IDisposable
    {
        public ISecurityOperations SecurityOperations { get; private set; }

        public SecurityOperationsFixture()
        {
            SecurityOperations = new SmsHub.Common.Implementations.SecurityOperations();
        }

        public void Dispose()
        {
        }
    }



}
