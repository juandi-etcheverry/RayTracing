using System;

namespace BusinessLogicExceptions
{
    public class SessionException : Exception
    {
        public SessionException(string message) : base(message)
        {
        }
    }
}