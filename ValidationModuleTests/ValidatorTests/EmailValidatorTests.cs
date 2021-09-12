using NUnit.Framework;
using ValidationModule;

namespace ValidationModuleTests
{
    public class EmailValidatorTests
    {
        private const string ValidLocalPartCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#$%&'*+-/=?^_`{|}~.\"(),:;<>@[\\]";
        private const string ValidDomainNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string ValidTopLevelDomainFirstCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string ValidTopLevelDomainCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private readonly EmailValidator _emailValidator = new();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmailATSymbolTest()
        {
            var emailValid = "@";
            var emailInvalid = "a";

            Assert.IsTrue(_emailValidator.ValidateAtSymbol(emailValid));
            Assert.IsFalse(_emailValidator.ValidateAtSymbol(emailInvalid));
        }

        [Test]
        public void EmailInvalidSymbolsTest()
        {
            foreach(var character in ValidLocalPartCharacters)
            {
                Assert.IsTrue(_emailValidator.ValidateInvalidSymbols(character.ToString()));
            }
            for(int i = 32; i <= 126; ++i) {
                if(!ValidLocalPartCharacters.Contains((char)i))
                    Assert.IsFalse(_emailValidator.ValidateInvalidSymbols(((char)i).ToString()));
            }
        }

        [Test]
        public void EmailValidDomainTest()
        {
            foreach (var character in ValidDomainNameCharacters)
            {
                Assert.IsTrue(_emailValidator.ValidateDomain(character.ToString()));
            }
            for (int i = 32; i <= 126; ++i)
            {
                if (!ValidDomainNameCharacters.Contains((char)i))
                    Assert.IsFalse(_emailValidator.ValidateDomain(((char)i).ToString()));
            }

            string[] validDomainNamesWithHyphen = { "a-a", "a--a", "a-a-a" };
            string[] invalidDomainNamesWithHyphen = { "-a", "a-", "-", "a-a-", "-a-a" };

            foreach(var email in validDomainNamesWithHyphen)
            {
                Assert.IsTrue(_emailValidator.ValidateDomain(email));
            }

            foreach (var email in invalidDomainNamesWithHyphen)
            {
                Assert.IsFalse(_emailValidator.ValidateDomain(email));
            }
        }

        [Test]
        public void EmailValidTopLevelDomainTest()
        {
            foreach (var character in ValidTopLevelDomainFirstCharacters)
            {
                Assert.IsTrue(_emailValidator.ValidateTopLevelDomain(character.ToString()));
            }
            for (int i = 32; i <= 126; ++i)
            {
                if (!ValidTopLevelDomainFirstCharacters.Contains((char)i))
                    Assert.IsFalse(_emailValidator.ValidateTopLevelDomain(((char)i).ToString()));
            }

            string[] validTopLevelDomains = { "xn--a", "a--a", "a-a-a", "a0--a", "a--0" };
            string[] invalidTopLevelDomains = { "xn--", "a-", "-", "a-a-", "-a-a", "0a", "0a--a" };

            foreach (var email in validTopLevelDomains)
            {
                Assert.IsTrue(_emailValidator.ValidateTopLevelDomain(email));
            }

            foreach (var email in invalidTopLevelDomains)
            {
                Assert.IsFalse(_emailValidator.ValidateTopLevelDomain(email));
            }
        }
    }
}