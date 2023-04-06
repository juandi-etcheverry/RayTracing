using System;

namespace BusinessLogic
{
    public class AlphanumericNameException : Exception
    {
        public AlphanumericNameException(string message) : base(message)
        {
        }
    }
}