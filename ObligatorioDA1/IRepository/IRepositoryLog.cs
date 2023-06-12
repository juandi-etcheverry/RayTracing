using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace IRepository
{
    public interface IRepositoryLog
    {
        IList<Log> GetAll();
        Log Add(Log x);
    }
}
