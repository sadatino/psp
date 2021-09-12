using System;

namespace ValidationModule
{
    public class PhoneValidator : IValidator<string>
    {
        public string ValidateAndTransform(string phone)
        {
            if (Validate(phone))
                return TransformCountryCode(phone);
            else
                return null;
        }

        public string TransformCountryCode(string phone)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string phone)
        {
            throw new NotImplementedException();
        }

        public bool ValidateOnlyNumbers(string phone)
        {
            throw new NotImplementedException();
        }

        public bool ValidateLength(string phone)
        {
            throw new NotImplementedException();
        }

        public bool ValidatePrefix(string phone)
        {
            throw new NotImplementedException();
        }
    }
}
