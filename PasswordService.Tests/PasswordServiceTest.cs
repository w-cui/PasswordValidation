using Xunit;
using Moq;

namespace Password.Services.Tests
{
    public class PasswordServiceTest
    {
        [Theory]
        // Invalid passwords
        [InlineData(null, false)]
        [InlineData(" ", false)]
        [InlineData("123", false)]
        [InlineData("veryverylooooongpassword", false)]
        [InlineData("123456", false)]
        [InlineData("abcdef", false)]
        [InlineData("123abc", false)]
        [InlineData("123ABC", false)]
        [InlineData("123ábC", false)]
        [InlineData("123aaabC", false)]
        [InlineData("P1zz@P1zz@P1zz@", false)]
        // Valid passwords
        [InlineData("123Abc", true)]
        [InlineData("123Abc.+[@\"", true)]
        [InlineData("iLovey0u!", true)]
        public void IsValid_GivenInput_Returns(string pwd, bool expected)
        {
            // Arrange
            var service = CreateService();

            // Act
            var actual = service.IsValid(pwd);

            // Assert
            Assert.Equal(expected, actual);
        }

        private PasswordService CreateService() 
        {
            return new PasswordService(
                new IRule [] 
                {
                    new Length(),
                    new Alphabet(),
                    new Digit(),
                    new Uppercase(),
                    new Lowercase(),
                    new LegalCharacter(),
                    new RepeatedCharacter(),
                    new RepeatedSubstring()
                }
            );
        }
    }
}
