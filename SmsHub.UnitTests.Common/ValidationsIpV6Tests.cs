using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;

namespace SmsHub.UnitTests.Common
{
    public class ValidationsIpV6Tests
    {
        [Fact]
        public void CheckValidIpV6_Four999Section_InvalidIpException()
        {
            string ip = "2001:0db8:0000:1234:999:999:999:999";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_MoreThan8section_InvalidIpException()
        {
            string ip = "2001:0db8:85a3:0000:0000:8a2e:0370:7334:1234";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_LessThan8section_InvalidIpException()
        {
            string ip = "2001:db8:85a3:370:7334";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
      

        [Fact]
        public void CheckValidIpV6_UseTreeColon_InvalidIpException()
        {
            string ip = "2001:db8:85a3:::0000:8a2e:0370:7334";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        } 
        
        [Fact]
        public void CheckValidIpV6_Use2ColonIn2Section_InvalidIpException()
        {
            string ip = "2001::85a3::7334";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        } 
        
        
        [Fact]
        public void CheckValidIpV6_UseSingleColonAtTheEnd_InvalidIpException()
        {
            string ip = "2001:db8::85a3:";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV6_UseOtherAlphabet_InvalidIpException()
        {
            string ip = "2001:db8:1234:5678:90ab:cedf:ghij:klmn";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV6_MoreThan4NumberInSection_InvalidIpException()
        {
            string ip = "12345:6789:abcd:ef01:2345:6789:abcd:ef01";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV6_OneSection999_InvalidIpException()
        {
            string ip = "2001:0db8:85a3:999:0000:8a2e:0370:7334";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        [Fact]
        public void CheckValidIpV6_NullAddress_InvalidIpException()
        {
            string ip = "";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV6_OneCharacter_InvalidIpException()
        {
            string ip = "a";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        [Fact]
        public void CheckValidIpV6_UseIpV4_InvalidIpException()
        {
            string ip = "138.255.30.12";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_IpV6WithSubnettingMoreThan128_InvalidIpException()
        {
            string ip = "2001:db8:85a3::8a2e:370:7334/129";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_IpV6WithSubnettingWithExtraColonAtTheEnd_InvalidIpException()
        {
            string ip = "2001:db8:85a3:370::7334/64:";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_IpV6With2Subnetting_InvalidIpException()
        {
            string ip = "2001:db8:85a3:0000:0000:8a2e:0370:7334/64/24";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_IpV6With1ColonBeforeSubnetting_InvalidIpException()
        {
            string ip = "2001:db8::85a3:/64";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }


        /// Validation Test
        [Fact]
        public void CheckValidIpV6_Two0Section_ValidIpException()
        {
            string ip = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_Tow0SectionInMiddleBySummarizing_ValidIpException()
        {
            string ip = "2001:db8::ff00:42:8329";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_Three0Section_ValidIpException()
        {
            string ip = "2001:0db8:0000:0042:0000:0000:8a2e:0370";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_Tow0SectionInTheEndBySummarizing_ValidIpException()
        {
            string ip = "2607:f0d0:1002:51::4";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }
        [Fact]
        public void CheckValidIpV6_Use2ColonAtTheEnd_ValidIpException()
        {
            string ip = "2001:db8:85a3::";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }
        [Fact]
        public void CheckValidIpV6_LocalTesting_ValidIpException()
        {
            string ip = "::1";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }
        
        [Fact]
        public void CheckValidIpV6_LocalNetwork_ValidIpException()
        {
            string ip = "fe80::1ff:fe23:4567:890a";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }
        
        [Fact]
        public void CheckValidIpV6_EmbeddedIpV4ToIpV6_ValidIpException()
        {
            string ip = "::ffff:192.168.1.1";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_IpV6WithSubnetting1_ValidIpException()
        {
            string ip = "2001:db8:abcd:0012::0/64";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_IpV6WithSubnetting2_ValidIpException()
        {
            string ip = "2001:db8:85a3::8a2e:370:7334/64";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        } 
        
        [Fact]
        public void CheckValidIpV6_IpV6WithSubnetting3_ValidIpException()
        {
            string ip = "2001:db8::/48";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        } 
        
        [Fact]
        public void CheckValidIpV6_IpV6WithSubnettingLoopBack_ValidIpException()
        {
            string ip = "::1/128";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

    }
}
