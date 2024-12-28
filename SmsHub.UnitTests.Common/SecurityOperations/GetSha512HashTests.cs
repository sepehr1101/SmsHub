using SmsHub.Common.Contrats;

namespace SmsHub.UnitTests.Common.SecurityOperations
{
    public class GetSha512HashTests : IClassFixture<SecurityOperationsFixture>
    {

        private readonly ISecurityOperations _securityOperations;
        string BaseInput = "سلام وقت بخیر 09920000000 آدرس:اصفهان-خیابان جی Email.com/Shamsaii_etehadi%asp.net <123>@!@#$%. سَلام";
        string BaseInputWithoutFathe = "سلام وقت بخیر 09920000000 آدرس:اصفهان-خیابان جی Email.com/Shamsaii_etehadi%asp.net <123>@!@#$%. سلام";
        string BaseInputWithoutSpace = "سلام وقتبخیر 09920000000 آدرس:اصفهان-خیابان جی Email.com/Shamsaii_etehadi%asp.net <123>@!@#$%. سَلام";


        public GetSha512HashTests(SecurityOperationsFixture fixture)
        {
            _securityOperations = fixture.SecurityOperations;
        }

        [Fact]
        public async Task GetSha512Hash_CheckNumberInputString_ValidInputString()
        {
            string input = "1";
            string inputHash = "Tf9Oo0DwqCPxXT9PAati6uDl2lecy4Ufjbnf6ExYsrN7iZA6dA4e4XLaeTpuedVg5ff5vQWKEqKAQz7W+kZRCg==";
            var result = await _securityOperations.GetSha512Hash(input);
            Assert.Equal(inputHash, result);
        }

        [Fact]
        public async Task GetSha512Hash_CheckInputStringWithHamzeAndPersianYe_ValidInputString()
        {
            string input = "شمسائی";
            string inputHash = "y4tSnji3x9OuYRwuDz9l+oVYWDGPrNV710OXykqsfNfehbkDvr3tXcaevJQclP8wtwYEbkcqQ7XYFIuZ2y3xxg==";
            var result = await _securityOperations.GetSha512Hash(input);
            Assert.Equal(inputHash, result);
        }

        [Fact]
        public async Task GetSha512Hash_CheckInputStringWithHamzeAndArabicYe_ValidInputString()
        {
            string input = "شمسائي";
            string inputHash = "4NIFI0b8D7/jAqfiW+aww8+iccW6tDP9AF1YPegLgE11XMyn3b8+WfqMX49BoK6DkxF+hrkrxZ6nJlRU9Yu5iw==";
            var result = await _securityOperations.GetSha512Hash(input);
            Assert.Equal(inputHash, result);
        }

        [Fact]
        public async Task GetSha512Hash_CheckInputStringWithTwoPersianYe_ValidInputString()
        {
            string input = "شمسایی";
            string inputHash = "dE/zrGHiBUCc/99/EEM9WAV2B8ev4SIiPckxuTD7HOzq6RBZtEjY3LIaH3wB4YxTXju254rxxo9NUFSAn/aLxg==";
            var result = await _securityOperations.GetSha512Hash(input);
            Assert.Equal(inputHash, result);
        }
        [Fact]
        public async Task GetSha512Hash_CheckInputStringWithTwoArabicYe_ValidInputString()
        {
            string input = "شمسايي";
            string inputHash = "jY1IEroVtq3goJIXhIJ8qzH6IYRw0UHvWpydqGk36SNIie3I5kzTYm/s3pids51znw7q2qdMMd0a4TijNoEScQ==";
            var result = await _securityOperations.GetSha512Hash(input);
            Assert.Equal(inputHash, result);
        }

        [Fact]
        public async Task GetSha512Hash_CheckInputStringWithArabicYeAndPersianYe_ValidInputString()
        {
            string input = "شمسايی";
            string inputHash = "MpPH0wmqHtWlrlsjxKu/UzF6ZD40xdHoaEHPGLWBWZqOUmBgQfJEqfj4KgN19gtunGWEsBx8hSNk4uMs2FGODQ==";
            var result = await _securityOperations.GetSha512Hash(input);
            Assert.Equal(inputHash, result);
        }

        [Fact]
        public async Task GetSha512Hash_CheckBaseInputString_ValidInputString()
        {
            string inputHash = "ANmZG+kT+tJfVX4cyYzaAwm0DC0KuTL/CNM1UkKWFRHvFakUiM5EOJSJ69eSoxeNkTdzr4UMgbZzTsVvfUW0SQ==";
            var result = await _securityOperations.GetSha512Hash(BaseInput);
            Assert.Equal(inputHash, result);
        }

        [Fact]
        public async Task GetSha512Hash_CheckBaseInputWithoutFathe_ValidInputString()
        {
            string inputHash = "gk4X+wgCx3ZQdbNGYXqoYhjRCRvsloVHRvTdHotFQtADvat2VzyjEN2gQ+77hDBMMuxk5G0vMf+dQQOVOxXUkA==";
            var result = await _securityOperations.GetSha512Hash(BaseInputWithoutFathe);
            Assert.Equal(inputHash, result);
        }

        [Fact]
        public async Task GetSha512Hash_CheckBaseInputWithoutSpace_ValidInputString()
        {
            string inputHash = "mOJPao7XlriWDIf/RVhJHx8no7UjqLuU6RRKf6YtM9wfiVGmLEa3NYsIQhn61nc+IuyUo7YUQEOpVaS8g0w1jQ==";
            var result = await _securityOperations.GetSha512Hash(BaseInputWithoutSpace);
            Assert.Equal(inputHash, result);
        }
    }
}
