using System;

namespace BusinessLogicExceptions
{
    public class PasswordException : Exception
    {
        public PasswordException(string message) : base(message) { }
    }
}
