using System;

namespace BusinessLogicExceptions
{
    public class ShapeNotInListException : Exception
    {
        public ShapeNotInListException(string message) : base(message)
        {
        }
    }
}
