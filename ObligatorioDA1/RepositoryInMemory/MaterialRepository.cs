using System.Collections.Generic;
using System.Linq;
using Domain;
using IRepository;

namespace RepositoryInMemory
{
    public class MaterialRepository : IRepositoryMaterial
    {
        private static readonly IList<Material> _materials = new List<Material>();

        public IList<Material> GetAll()
        {
            return _materials;
        }

        public List<Material> FindMany(string name)
        {
            return _materials.Where(m => m.Name.ToLower().Equals(name.ToLower())).ToList();
        }

        public Material Add(Material x)
        {
            _materials.Add(x);
            return x;
        }

        public Material Remove(Material x)
        {
            _materials.Remove(x);
            return x;
        }
    }
}