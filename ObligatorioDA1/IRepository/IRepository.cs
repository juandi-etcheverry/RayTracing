using System.Collections.Generic;

namespace IRepository
{
    public interface IRepository<T> where T: class
    {
        IList<T> GetAll();
        T Get(string name);
        T Add(T x);
        T Remove(T x);
    }
}
