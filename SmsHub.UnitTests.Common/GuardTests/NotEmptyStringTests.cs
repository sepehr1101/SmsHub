using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;

namespace SmsHub.UnitTests.Common.GuardTests
{
    public class NotEmptyStringTests
    {
        [Fact]
        public void NotEmptyString_IntObject_InvalidInputObject()
        {
            int input = 123;
            var result = Guard.NotEmptyString(input, nameof(input));

            Assert.Equal(input.ToString(), result);
        }
        [Fact]
        public void NotEmptyString_IntNullObject_InvalidInputObject()
        {
            int? input = null;
            var result=()=>Guard.NotEmptyString(input, nameof(input));

           Assert.Throws<ArgumentIsNullException>(result);
        }
        [Fact]
        public void NotEmptyString_StringNullObject_InvalidInputObject()
        {
            string input=null;
            var result=()=>Guard.NotEmptyString(input,nameof(input));

            Assert.Throws<ArgumentIsNullException>(result);
        }

        [Fact]
        public void NotEmptyString_StringNotNullObject_ValidInputObject()
        {
            string input= "Sample";
            var result=Guard.NotEmptyString(input, nameof(input));

            Assert.Equal(input,result);
        }
        [Fact]
        public void NotEmptyString_StringWithSpace_InvalidInputObject()
        {
            string input = "    ";
            var result=()=> Guard.NotEmptyString(input, nameof(input));

            Assert.Throws<ArgumentException>(result);
        }
    }
}
