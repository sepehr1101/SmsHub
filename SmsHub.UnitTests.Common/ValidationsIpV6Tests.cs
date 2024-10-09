using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;

namespace SmsHub.UnitTests.Common
{
    public class ValidationsIpV6Tests
    {
        [Fact]
        public void CheckValidIpV6_MoreThan255Section1_InvalidIpException()
        {
            string ip = "";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
    }
}
