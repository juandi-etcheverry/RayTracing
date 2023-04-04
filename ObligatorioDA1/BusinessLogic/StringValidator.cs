using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class StringValidator
    {
        public static bool HasSpaces(string stringToValidate)
        {
            return stringToValidate.HasSpaces();
        }

        public static bool HasTrailingSpaces(string stringToValidate)
        {
            return stringToValidate.HasTrailingSpaces();
        }

        public static bool IsEmpty(string stringToValidate)
        {
            return stringToValidate.IsEmpty();
        }
    }

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
    }
}