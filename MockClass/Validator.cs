using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockClass
{
    public class Validator
    {
        int minKeys = 6;

        List<string> specialSymbols = new List<string>
        {
            "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+"
        };
        public bool PasswordChecker(string password)
        {
            return true;
        }

        public bool PhoneValidator()
        {
            return true;

        }

        public bool EmailValidator(string email)
        {
            return true;
        }
    }
}
