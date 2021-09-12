using NUnit.Framework;
using System.Linq;
using ValidationModule;

namespace ValidationModuleTests
{
    public class PasswordValidatorTests
    {
        private readonly char[] _specialSymbols = { '!', '#', '%', '&' };
        private const int maxLenght = 8;
        private readonly PasswordValidator _passwordValidator = new();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MaxPasswordLengthTest()
        {
            var password = "";
            for (int i = 0; i < maxLenght; ++i)
            {
                password += "a";
            }

            Assert.IsTrue(_passwordValidator.ValidateLength(password));

            password += "a";

            Assert.IsFalse(_passwordValidator.ValidateLength(password));
        }

        [Test]
        public void UppercasePasswordTest()
        {
            var passwordWithUppercase = "A";
            var passwordWithoutUppercase = "a";

            Assert.IsTrue(_passwordValidator.ValidateUppercase(passwordWithUppercase));
            Assert.IsFalse(_passwordValidator.ValidateUppercase(passwordWithoutUppercase));
        }

        [Test]
        public void SpecialSymbolPasswordTest()
        {
            var passwordWithoutSpecialSymbol = "a";
            var passwordWithSpecialSymbol = passwordWithoutSpecialSymbol + _specialSymbols.First();

            Assert.IsTrue(_passwordValidator.ValidateSpecialSymbols(passwordWithSpecialSymbol));
            Assert.IsFalse(_passwordValidator.ValidateSpecialSymbols(passwordWithoutSpecialSymbol));
        }
    }
}