using NUnit.Framework;

namespace PasswordValidation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        // INVALID PASSWORDS
        [TestCase("P1zz@", ExpectedResult = false)]
        [TestCase("P1zz@P1zz@P1zz@P1zz@P1zz@", ExpectedResult = false)]
        [TestCase("mypassword11", ExpectedResult = false)]
        [TestCase("MYPASSWORD11", ExpectedResult = false)]
        [TestCase("iLoveYou", ExpectedResult = false)]
        [TestCase("Pè7$areLove", ExpectedResult = false)]
        [TestCase("Repeeea7!", ExpectedResult = false)]
        // VALID PASSWORDS
        [TestCase("H4(k+x0", ExpectedResult = true)]
        [TestCase("Fhg93@", ExpectedResult = true)]
        [TestCase("aA0!@#$%^&*()+=_-{}[]:;\"", ExpectedResult = true)]
        [TestCase("zZ9'?<>,.", ExpectedResult = true)]
        public static bool Test_PasswordValidation(string pwd)
        {
            var validator = new PasswordValidator(new IValidationRule[] {
                new ScopeRule(),
                new LengthRule(),
                new UppercaseRule(),
                new LowercaseRule(),
                new DigitRule(),
                new RepeatingCharRule(),
                new RepeatingSubstrRule(),
            });
            bool isValid = validator.IsValid(pwd);
            return isValid;
        }
    }
}