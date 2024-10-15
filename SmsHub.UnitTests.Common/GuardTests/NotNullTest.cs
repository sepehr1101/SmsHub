using SmsHub.Common.Exceptions;
using SmsHub.Common.Extensions;
using System.Dynamic;
using Xunit.Abstractions;

namespace SmsHub.UnitTests.Common.GuardTests
{
    public class NotNullTest
    {
        [Fact]
        public void NotNull_StringIsNull_InvalidInputObject()
        {
            string input = null;
            var result = () => Guard.NotNull(input);

            Assert.Throws<ArgumentIsNullException>(result);
        }

        [Fact]
        public void NotNull_IntIsNull_InvalidInputObject()
        {
            int? input = null;
            var result = () => Guard.NotNull(input);

            Assert.Throws<ArgumentIsNullException>(result);
        }

        [Fact]
        public void NotNull_ClassIsNull_InvalidInputObject()
        {
            NullTestCase input = null;
            var result = () => Guard.NotNull(input);

            Assert.Throws<ArgumentIsNullException>(result);
        }
        [Fact]
        public void NotNull_PropertyIsNull_InvalidInputObject()
        {
            var input = new NullTestCase { Name = null };
            var result = () => Guard.NotNull(input.Name);

            Assert.Throws<ArgumentIsNullException>(result);
        }

        [Fact]
        public void NotNull_DynamicIsNull_InvalidInputObject()
        {
            dynamic input=null;
            var result = () => Guard.NotNull((object)(input));

            Assert.Throws<ArgumentIsNullException>(result);
        }
        
        [Fact]
        public void NotNull_PropertyInDynamicIsNull_InvalidInputObject()
        {
            string nullValue = null;
            dynamic input= new{ Name=nullValue ,Id=1 };
            var result = () => Guard.NotNull((object)(input.Name));

            Assert.Throws<ArgumentIsNullException>(result);
        }

        [Fact]
        public void NotNull_ExpandoObjectIsNull_InvalidInputObject()
        {
            dynamic input = new ExpandoObject();
            input.name = null;
            var result = () => Guard.NotNull((object)(input.name));

            Assert.Throws<ArgumentIsNullException>(result);
        }
    }
}
