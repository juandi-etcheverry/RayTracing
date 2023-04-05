using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ShapeNotInListException : Exception
    {
        public ShapeNotInListException(string message) : base(message)
        {
        }
    }
}
