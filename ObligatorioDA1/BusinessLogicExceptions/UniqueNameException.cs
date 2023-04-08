using System;

namespace BusinessLogicExceptions
{
    public class UniqueNameException : Exception
    {
        public UniqueNameException(string message) : base(message)
        {
        }
    }
}
