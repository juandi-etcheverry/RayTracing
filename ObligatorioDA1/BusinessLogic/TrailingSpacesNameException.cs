using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TrailingSpacesNameException : Exception
    {
        public TrailingSpacesNameException(string message) : base(message)
        {
        }
    }
}
