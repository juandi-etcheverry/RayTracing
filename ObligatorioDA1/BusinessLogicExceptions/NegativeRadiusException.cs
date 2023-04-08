using System;

namespace BusinessLogicExceptions
{
    public class NegativeRadiusException : Exception
    {
        public NegativeRadiusException(string message) : base(message)
        {
        }
    }
}
