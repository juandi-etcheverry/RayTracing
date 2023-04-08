using System;

namespace BusinessLogicExceptions
{
    public class EmptyNameException : Exception
    {
        public EmptyNameException(string message) : base(message)
        {
        }
    }
}
