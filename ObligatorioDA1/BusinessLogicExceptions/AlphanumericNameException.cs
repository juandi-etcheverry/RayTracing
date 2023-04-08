using System;

namespace BusinessLogicExceptions
{
    public class AlphanumericNameException : Exception
    {
        public AlphanumericNameException(string message) : base(message)
        {
        }
    }
}