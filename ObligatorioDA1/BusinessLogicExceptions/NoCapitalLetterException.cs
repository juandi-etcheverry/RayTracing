using System;

namespace BusinessLogicExceptions
{
    public class NoCapitalLetterException: Exception
    {
        public NoCapitalLetterException(string message) : base(message)
        {
        }
    }
}
