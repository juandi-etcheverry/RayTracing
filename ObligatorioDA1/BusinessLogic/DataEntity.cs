using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public abstract class DataEntity
    {
        public abstract bool AreNamesEqual<T>(T other) where T : DataEntity;

        public abstract void ThrowNameExists();
    }
}
