using System;

namespace BusinessLogicExceptions
{
    public class TrailingSpacesNameException : Exception
    {
        public TrailingSpacesNameException(string message) : base(message)
        {
        }
    }
}
