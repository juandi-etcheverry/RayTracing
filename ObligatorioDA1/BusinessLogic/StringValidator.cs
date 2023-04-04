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
            return string.IsNullOrEmpty(stringToValidate);
        }

        public static bool IsBetween(this string stringToValidate, uint minLength, uint maxLength)
        {
            return stringToValidate.Length <= maxLength && stringToValidate.Length >= minLength;
        }

        public static bool IsAlphaNumeric(this string stringToValidate)
        {
            return stringToValidate.All(char.IsLetterOrDigit) && !stringToValidate.IsEmpty();
        }

        public static bool HasUpper(this string stringToValidate, uint uppercaseLetterAmount = 1)
        {
            return stringToValidate.Count(char.IsUpper) == uppercaseLetterAmount;
        }
    }
}