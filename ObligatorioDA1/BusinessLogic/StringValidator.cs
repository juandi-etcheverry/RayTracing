using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class StringValidatorExtension
    {
        public static bool HasSpaces(this string stringToValidate)
        {
            return stringToValidate.Contains(" ");
        }

        public static bool HasTrailingSpaces(this string stringToValidate)
        {
            return stringToValidate.StartsWith(" ") || stringToValidate.EndsWith(" ");
        }

        public static bool IsEmpty(this string stringToValidate)
        {
            return stringToValidate.Length == 0;
        }

        public static bool IsBetween(this string stringToValidate, int minLength, int maxLength)
        {
            return stringToValidate.Length <= maxLength && stringToValidate.Length >= minLength;
        }       
    }
}