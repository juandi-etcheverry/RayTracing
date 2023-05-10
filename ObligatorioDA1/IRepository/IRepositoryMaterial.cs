using System.Collections.Generic;
using Domain;

namespace IRepository
{
    public interface IRepositoryMaterial : IRepository<Material>
    {
        List<Material> FindMany(string name);
    }
}