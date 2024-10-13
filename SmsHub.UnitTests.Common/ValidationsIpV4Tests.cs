using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;

namespace SmsHub.UnitTests.Common
{
    public class ValidationsIpV4Tests
    {
        [Fact]
        public void CheckValidIpV4_MoreThan255Section1_InvalidIpException()
        {
            string ip = "280.30.12.11";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_MoreThan255Section2_InvalidIpException()
        {
            string ip = "220.300.12.11";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_MoreThan255Section3_InvalidIpException()
        {
            string ip = "200.10.266.38";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_MoreThan255Section4_InvalidIpException()
        {
            string ip = "200.169.33.305";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_MoreThan4Sections_InvalidIpException()
        {
            string ip = "200.10.25.3.25";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_NumberAndOtherCharacters_InvalidIpException()
        {
            string ip = "=102.12-.3";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_JustOneSection_InvalidIpException()
        {
            string ip = "5";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_OneSectionMoreThan255_InvalidIpException()
        {
            string ip = "258";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_Empty_InvalidIpException()
        {
            string ip = "";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_JustDot_InvalidIpException()
        {
            string ip = ".";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_JustBackSlash_InvalidIpException()
        {
            string ip = @"\";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_TowSectionWithSlash_InvalidIpException()
        {
            string ip = @"600.2/";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_OneSectionWithNumberAndOtherSectionsNull_InvalidIpException()
        {
            string ip = "10...";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_4SectionNumberAndCharacter_InvalidIpException()
        {
            string ip = "+10.2.2-5.?5";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_2Sections_InvalidIpException()
        {
            string ip = "111.1111";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_First2SectionsMoreThan255_InvalidIpException()
        {
            string ip = "300.280.13.52";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_SecondSectionMoreThan255_InvalidIpException()
        {
            string ip = "46.510.230.89";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_OneSectionEqual256_InvalidIpException()
        {
            string ip = "255.200.256.30";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_4SectionByMore0_ValidIpException()
        {
            string ip = "009.003.005.000";
            try
            {
                IpValidations.CheckValidIpV4(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CheckValidIpV4_AllSectionsEqualToZero_ValidIpException()
        {
            string ip = "00.0.0.0";
            try
            {
                IpValidations.CheckValidIpV4(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CheckValidIpV4_AllSectionsEqualTo1_ValidIpException()
        {
            string ip = "1.1.1.1";
            try
            {
                IpValidations.CheckValidIpV4(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);    
            }
        }

        [Fact]
        public void CheckValidIpV4_AllSectionsEqualTo255_ValidIpException()
        {
            string ip = "255.255.255.255";
            try
            {
                IpValidations.CheckValidIpV4(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
