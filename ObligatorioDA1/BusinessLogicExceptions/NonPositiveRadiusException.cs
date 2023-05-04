using System;

namespace BusinessLogicExceptions
{
    public class NonPositiveRadiusException : Exception
    {
        public NonPositiveRadiusException(string message) : base(message)
        {
        }
    }
}
