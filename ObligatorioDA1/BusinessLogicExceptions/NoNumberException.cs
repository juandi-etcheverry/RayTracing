using System;

namespace BusinessLogicExceptions
{
    public class NoNumberException: Exception
    {
        public NoNumberException(string message) : base(message)
        {
        }
    }
}
