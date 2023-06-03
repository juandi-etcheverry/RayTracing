using System.Collections.Generic;

namespace IRepository
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        T Add(T x);
        T Remove(T x);
        T Update(T x, string newName);
    }
}