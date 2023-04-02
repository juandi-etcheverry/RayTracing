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
            if (stringToValidate.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}
