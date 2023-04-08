using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NegativeRadiusException : Exception
    {
        public NegativeRadiusException(string message) : base(message)
        {
        }
    }
}
