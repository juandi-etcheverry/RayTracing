using System.Collections.Generic;
using Domain;

namespace IRepository
{
    public interface IRepositoryModel : IRepository<Model>
    {
        List<Model> FindMany(string name);
    }
}