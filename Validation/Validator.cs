using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validation
{
    public class Validator
    {
        int minKeys = 6;

        List<char> specialSymbols = new List<char>
        {
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+'
        };
        public static bool PasswordChecker(string password)
        {
            return true;
        }

        public static bool PhoneValidator(string phoneNumber, int phoneNumberLength, string phoneNumberPrefix)
        {
            return false;

        }

        public static bool EmailValidator(string email)
        {
            return true;
        }
    }
}
