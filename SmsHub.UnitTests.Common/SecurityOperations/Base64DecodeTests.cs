using SmsHub.Common.Contrats;

namespace SmsHub.UnitTests.Common.SecurityOperations
{
    public class Base64DecodeTests:IClassFixture<SecurityOperationsFixture>
    {
        private readonly ISecurityOperations _securityOperations;
        public Base64DecodeTests(SecurityOperationsFixture fixture)
        {
            _securityOperations = fixture.SecurityOperations;
        }
        [Fact]
        public void Base64Decode_CheckNumberString_ValidDecoding()
        {
            string input = "MQ==";
            string output = "1";
            var result = _securityOperations.Base64Decode(input);
            Assert.Equal(output, result);
        }
        
        [Fact]
        public void Base64Decode_CheckStringWithUpperAndLowerAndCaracter_ValidDecoding()
        {
            string input = "dGhpcyBJcyBTQU1QTEUgdGV4dCA6KQ==";
            string output = "this Is SAMPLE text :)";
            var result = _securityOperations.Base64Decode(input);
            Assert.Equal(output, result);
        }
        
        [Fact]
        public void Base64Decode_CheckMathString_ValidDecoding()
        {
            string input = "bG9nKDgpMiArIDcgPSAxMA==";
            string output = "log(8)2 + 7 = 10";
            var result = _securityOperations.Base64Decode(input);
            Assert.Equal(output, result);
        }

        [Fact]
        public void Base64Decode_CheckBaseInput_ValidDecoding()
        {
            var input = "2LPZjtmE2KfZhSAhINin24zZhiDbjNmQ2qkg2KzZj9mF2YTZhyDYrNmO2YfYqiDYqtiz2Kog2YXZkNiq2Y/YryDYp9mO2LPYqg==";
            var output = "سَلام ! این یِک جُمله جَهت تست مِتُد اَست";
            var result=_securityOperations.Base64Decode(input);
            Assert.Equal(output, result);
        }

        [Fact]
        public void Base64Decode_CheckBaseInputWithoutExclamationMark_ValidDecoding()
        {
            var input = "2LPZjtmE2KfZhSAg2KfbjNmGINuM2ZDaqSDYrNmP2YXZhNmHINis2Y7Zh9iqINiq2LPYqiDZhdmQ2KrZj9ivINin2Y7Ys9iq";
            var output = "سَلام  این یِک جُمله جَهت تست مِتُد اَست";
            var result= _securityOperations.Base64Decode(input);
            Assert.Equal(output, result);
        }
    }
}
