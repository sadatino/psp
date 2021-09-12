using System;

namespace ValidationModule
{
    public class EmailValidator : IValidator<string>
    {
        public bool Validate(string email)
        {
            return ValidateAtSymbol(email) && ValidateInvalidSymbols(email) && ValidateDomain(email) && ValidateTopLevelDomain(email);
        }

        public bool ValidateAtSymbol(string email)
        {
            throw new NotImplementedException();
        }

        public bool ValidateInvalidSymbols(string email)
        {
            throw new NotImplementedException();
        }

        public bool ValidateDomain(string email)
        {
            throw new NotImplementedException();
        }

        public bool ValidateTopLevelDomain(string email)
        {
            throw new NotImplementedException();
        }
    }
}
