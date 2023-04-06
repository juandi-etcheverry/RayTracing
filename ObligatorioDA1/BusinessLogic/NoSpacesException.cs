using System;

namespace BusinessLogic
{
    public class NoSpacesException : Exception
    {
        public NoSpacesException(string message) : base(message)
        {
        }
    }
}