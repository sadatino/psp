using System;

namespace ValidationModule
{
    public class PasswordValidator : IValidator<string>
    {
        public bool Validate(string password)
        {
            return ValidateLength(password) && ValidateSpecialSymbols(password) && ValidateUppercase(password);
        }

        public bool ValidateLength(string password)
        {
            throw new NotImplementedException();
        }
        public bool ValidateSpecialSymbols(string password)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUppercase(string password) // how about lowercase
        {
            throw new NotImplementedException();
        }
    }
}
