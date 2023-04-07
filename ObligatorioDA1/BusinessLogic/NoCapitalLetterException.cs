using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NoCapitalLetterException: Exception
    {
        public NoCapitalLetterException(string message) : base(message)
        {
        }
    }
}
