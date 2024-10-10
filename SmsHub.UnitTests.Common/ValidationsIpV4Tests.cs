using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;
using Xunit.Sdk;

namespace SmsHub.UnitTests.Common
{
    public class ValidationsIpV4Tests
    {
        [Fact]
        public void CheckValidIpV4_MoreThan255Section1_InvalidIpException()
        {
            string ip = "280.300.12.11";
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
        public void CheckValidIpV4_MoreThan4Section_InvalidIpException()
        {
            string ip = "200.10.25.3.25";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }


        [Fact]
        public void CheckValidIpV4_NumberAndOtherCharacter_InvalidIpException()
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
        public void CheckValidIpV4_null_InvalidIpException()
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
        public void CheckValidIpV4_JustSlash_InvalidIpException()
        {
            string ip = "\\";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }


        [Fact]
        public void CheckValidIpV4_TowSectionWithSlash_InvalidIpException()
        {
            string ip = "600.2/";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_OneSectionWithNumberAndOtherSectionNull_InvalidIpException()
        {
            string ip = "10...";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }

        [Fact]
        public void CheckValidIpV4_4SectionHasNumberAndCharacter_InvalidIpException()
        {
            string ip = "+10.2.2-5.?5";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        [Fact]
        public void CheckValidIpV4_2SectionBy1_InvalidIpException()
        {
            string ip = "111.1111";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        [Fact]
        public void CheckValidIpV4_2FirstSectionMoreThan255_InvalidIpException()
        {
            string ip = "300.280.13.52";
            var action = () => IpValidations.CheckValidIpV4(ip);
            Assert.Throws<InvalidIpException>(action);
        }
        [Fact]
        public void CheckValidIpV4_2SecondSectionMoreThan255_InvalidIpException()
        {
            string ip = "46.510.230.890";
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


        //Validation Ip Exception
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
                Assert.False(false);
            }

        }
        [Fact]
        public void CheckValidIpV4_AllSection0_ValidIpException()
        {
            string ip = "00.0.0.0";
            try
            {
                IpValidations.CheckValidIpV4(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }
        [Fact]
        public void CheckValidIpV4_AllSection11_ValidIpException()
        {
            string ip = "1.1.1.1";
            try
            {
                IpValidations.CheckValidIpV4(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);    
            }
        }
        [Fact]
        public void CheckValidIpV4_AllSection255_ValidIpException()
        {
            string ip = "255.255.255.255";
            try
            {
                IpValidations.CheckValidIpV4(ip);
                Assert.True(true);
            }
            catch
            {
                Assert.False (false);
            }
        }
    }
}
