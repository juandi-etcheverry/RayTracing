using System;

namespace BusinessLogicExceptions
{
    public class NotInRangeException: Exception
    {
        public NotInRangeException(string message) : base(message)
        {
        }
    }
}
