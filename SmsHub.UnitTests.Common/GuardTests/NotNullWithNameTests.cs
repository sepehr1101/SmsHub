using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;
using System.Dynamic;

namespace SmsHub.UnitTests.Common.GuardTests
{
    public class NotNullWithNameTests
    {
        [Fact]
        public void NotNullWithName_StringIsNull_InvalidInputObject()
        {
            string input = null;
            var result = () => Guard.NotNull(input,nameof(input));

            Assert.Throws<ArgumentIsNullException>(result);
        }

        [Fact]
        public void NotNullWithName_IntIsNull_InvalidInputObject()
        {
            int? input = null;
            var result = () => Guard.NotNull(input,nameof(input));

            Assert.Throws<ArgumentIsNullException>(result);
        }

        [Fact]
        public void NotNullWithName_ClassIsNull_InvalidInputObject()
        {
            NullTestCase input = null;
            var result = () => Guard.NotNull(input,nameof(input));

            Assert.Throws<ArgumentIsNullException>(result);
        }
        [Fact]
        public void NotNullWithName_PropertyIsNull_InvalidInputObject()
        {
            var input = new NullTestCase { Name = null };
            var result = () => Guard.NotNull(input.Name,nameof(input));

            Assert.Throws<ArgumentIsNullException>(result);
        }

        [Fact]
        public void NotNullWithName_DynamicIsNull_InvalidInputObject()
        {
            dynamic input = null;
            var result = () => Guard.NotNull((object)(input), nameof(input));

            Assert.Throws<ArgumentIsNullException>(result);
        }

        [Fact]
        public void NotNullWithName_PropertyInDynamicIsNull_InvalidInputObject()
        {
            string nullValue = null;
            dynamic input = new { Name = nullValue, Id = 1 };
            var result = () => Guard.NotNull((object)(input.Name), nameof(input));

            Assert.Throws<ArgumentIsNullException>(result);
        }

        [Fact]
        public void NotNullWithName_ExpandoObjectIsNull_InvalidInputObject()
        {
            dynamic input = new ExpandoObject();
            input.name = null;
            var result = () => Guard.NotNull((object)(input.name), nameof(input));

            Assert.Throws<ArgumentIsNullException>(result);
        }
    }
}
