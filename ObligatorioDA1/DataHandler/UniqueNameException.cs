using System;

namespace DataHandlers
{
    public class UniqueNameException : Exception
    {
        public UniqueNameException(string message) : base(message)
        {
        }
    }
}