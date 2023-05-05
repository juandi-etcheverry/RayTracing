using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicExceptions
{
    public class AssociationException: Exception
    {
        public AssociationException(string message) : base(message)
        {
        }
    }
}
