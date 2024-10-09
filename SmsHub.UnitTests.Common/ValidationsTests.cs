using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;

namespace SmsHub.UnitTests.Common
{   
    public class ValidationsTests
    {
        [Fact]
        public void CheckValidIpV4_MoreThan255Section1_InvalidIpException() 
        {
            string ip = "256.13.12.11";
            var action = () => Validations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }
    }
}
