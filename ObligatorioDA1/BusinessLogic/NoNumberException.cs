using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NoNumberException: Exception
    {
        public NoNumberException(string message) : base(message)
        {
        }
    }
}
