using SmsHub.Common.Contrats;
using SmsHub.UnitTests.Common.SecurityOperations;

namespace SmsHub.UnitTests.Common.SecurityOperations
{
    public class Base64EncodeTests:IClassFixture<SecurityOperationsFixture>
    {
        private readonly ISecurityOperations _securityOpertions;
        string baseInput = "سَلام ! این یِک جُمله جَهت تست مِتُد اَست";
        string baseInputWithoutExclamationMark = "سَلام  این یِک جُمله جَهت تست مِتُد اَست";

        public Base64EncodeTests(SecurityOperationsFixture fixture)
        {
            _securityOpertions = fixture.SecurityOperations;
        }

        [Fact]
        public void Base64Encode_CheckNumberString_ValidInputString()
        {
            var input = "1";
            var output = "MQ==";
            var result=_securityOpertions.Base64Encode(input);
            Assert.Equal(output, result);
        }
        
        [Fact]
        public void Base64Encode_CheckStringWithUpperAndLowerAndCaracter_ValidInputString()
        {
            string input = "this Is SAMPLE text :)";
            string output = "dGhpcyBJcyBTQU1QTEUgdGV4dCA6KQ==";
            var result=_securityOpertions.Base64Encode(input);
            Assert.Equal(output, result);
        }

        [Fact]
        public void Base64Encode_CheckMathString_ValidInputString()
        {
            string input = "log(8)2 + 7 = 10";
            string output = "bG9nKDgpMiArIDcgPSAxMA==";
            var result = _securityOpertions.Base64Encode(input);
            Assert.Equal(output, result);
        }
        
        [Fact]
        public void Base64Encode_CheckBaseInput_ValidInputString()
        {
            var output = "2LPZjtmE2KfZhSAhINin24zZhiDbjNmQ2qkg2KzZj9mF2YTZhyDYrNmO2YfYqiDYqtiz2Kog2YXZkNiq2Y/YryDYp9mO2LPYqg==";
            var result = _securityOpertions.Base64Encode(baseInput);
            Assert.Equal(output, result);
        }
        
        [Fact]
        public void Base64Encode_CheckBaseInputWithoutExclamationMark_ValidInputString()
        {
            var output = "2LPZjtmE2KfZhSAg2KfbjNmGINuM2ZDaqSDYrNmP2YXZhNmHINis2Y7Zh9iqINiq2LPYqiDZhdmQ2KrZj9ivINin2Y7Ys9iq";
            var result = _securityOpertions.Base64Encode(baseInputWithoutExclamationMark);
            Assert.Equal(output, result);
        }
        
    }
}
