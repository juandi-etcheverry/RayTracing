using System;

namespace BusinessLogicExceptions
{
    public class AssociationException : Exception
    {
        public AssociationException(string message) : base(message)
        {
        }
    }
}