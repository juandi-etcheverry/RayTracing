using System;

namespace BusinessLogicExceptions
{
    public class SessionAlreadyInitializedException: Exception
    {
        public SessionAlreadyInitializedException(string message) : base(message)
        {
        }
    }
}
