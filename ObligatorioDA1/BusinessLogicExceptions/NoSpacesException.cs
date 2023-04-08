using System;

namespace BusinessLogicExceptions
{
    public class NoSpacesException : Exception
    {
        public NoSpacesException(string message) : base(message)
        {
        }
    }
}