using NUnit.Framework;
using ValidationModule;

namespace ValidationModuleTests
{
    public class PhoneValidatorTests
    {
        private readonly PhoneValidator _phoneValidator = new();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PhoneOnlyNumbersTest()
        {
            var phoneOnlyNumbers = "1";
            var phoneNotOnlyNumbers = "1a";

            Assert.IsTrue(_phoneValidator.ValidateOnlyNumbers(phoneOnlyNumbers));
            Assert.IsFalse(_phoneValidator.ValidateOnlyNumbers(phoneNotOnlyNumbers));
        }

        [Test]
        public void PhoneTransformablePrefixTransformationTest()
        {
            var phoneToTransform = "8";
            var expectedTransformedPhone = "+370";

            Assert.Equals(_phoneValidator.TransformCountryCode(phoneToTransform), expectedTransformedPhone);
        }

        [Test]
        public void PhoneNonTransformablePrefixTransformationTest()
        {
            var phoneToTransform = "7";

            Assert.Equals(_phoneValidator.TransformCountryCode(phoneToTransform), phoneToTransform);
        }
    }
}