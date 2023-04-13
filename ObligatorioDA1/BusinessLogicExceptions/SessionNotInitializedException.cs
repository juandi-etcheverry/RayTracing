using System;

namespace BusinessLogicExceptions
{
    public class SessionNotInitializedException: Exception
    {
        public SessionNotInitializedException(string message) : base(message)
        {
        }
    }
}
