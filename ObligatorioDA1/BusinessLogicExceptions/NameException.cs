using System;

namespace BusinessLogicExceptions
{
    public class NameException : Exception
    {
        public NameException(string message) : base(message)  { }
    }
}
