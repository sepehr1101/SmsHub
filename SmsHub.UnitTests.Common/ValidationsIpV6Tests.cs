using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;

namespace SmsHub.UnitTests.Common
{
    public class ValidationsIpV6Tests
    {
        [Fact]
        public void CheckValidIpV6_LastFourSectionsEquealTo999_InvalidIpException()
        {
            string ip = "2001:0db8:0000:1234:999:999:999:999";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_MoreThan8Section_InvalidIpException()
        {
            string ip = "2001:0db8:85a3:0000:0000:8a2e:0370:7334:1234";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_LessThan8Section_InvalidIpException()
        {
            string ip = "2001:db8:85a3:370:7334";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }      

        [Fact]
        public void CheckValidIpV6_ThreeConsecutiveColons_InvalidIpException()
        {
            string ip = "2001:db8:85a3:::0000:8a2e:0370:7334";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        } 
        
        [Fact]
        public void CheckValidIpV6_TwoConsecutiveColons_InvalidIpException()
        {
            string ip = "2001::85a3::7334";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        } 
                
        [Fact]
        public void CheckValidIpV6_SingleColonAtTheEnd_InvalidIpException()
        {
            string ip = "2001:db8::85a3:";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV6_UseInvalidCharacters_InvalidIpException()
        {
            string ip = "2001:db8:1234:5678:90ab:cedf:ghij:klmn";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV6_MoreThan4CharactersInSection_InvalidIpException()
        {
            string ip = "12345:6789:abcd:ef01:2345:6789:abcd:ef01";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV6_OneOfSectionsEqualTo999_InvalidIpException()
        {
            string ip = "2001:0db8:85a3:999:0000:8a2e:0370:7334";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV6_Empty_InvalidIpException()
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
        public void CheckValidIpV6_SubnettingMoreThan128_InvalidIpException()
        {
            string ip = "2001:db8:85a3::8a2e:370:7334/129";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_SubnettingWithExtraColonAtTheEnd_InvalidIpException()
        {
            string ip = "2001:db8:85a3:370::7334/64:";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_MultipleSubnetting_InvalidIpException()
        {
            string ip = "2001:db8:85a3:0000:0000:8a2e:0370:7334/64/24";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        
        [Fact]
        public void CheckValidIpV6_ColonBeforeSubnetting_InvalidIpException()
        {
            string ip = "2001:db8::85a3:/64";
            var action = () => IpValidations.CheckValidIpV6(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV6_TwoConsecutiveSectionsEqualTo0000_IpIsValid()
        {
            string ip = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_Tow0SectionsBySummarizing_IpIsValid()
        {
            string ip = "2001:db8::ff00:42:8329";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_ThreeSectionsEqualtTo0000_IpIsValid()
        {
            string ip = "2001:0db8:0000:0042:0000:0000:8a2e:0370";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_Tow0SectionInTheEndBySummarizing_IpIsValid()
        {
            string ip = "2607:f0d0:1002:51::4";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_Use2ColonsAtTheEnd_IpIsValid()
        {
            string ip = "2001:db8:85a3::";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_LoopbackIp_IpIsValid()
        {
            string ip = "::1";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
        
        [Fact]
        public void CheckValidIpV6_LocalIp_IpIsValid()
        {
            string ip = "fe80::1ff:fe23:4567:890a";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_NormalIp_IpIsValid()
        {
            string ip = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CheckValidIpV6_EmbeddedIpV6WithV4_IpIsValid()
        {
            string ip = "::ffff:192.168.1.1";
            try
            {
                IpValidations.CheckValidIpV6(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
