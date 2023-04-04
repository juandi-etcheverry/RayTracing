using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UniqueNameException : Exception
    {
        public UniqueNameException(string message) : base(message)
        {
        }
    }
}
