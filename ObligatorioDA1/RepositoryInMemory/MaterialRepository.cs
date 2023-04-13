using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Material Get(string name)
        {
            return _materials.FirstOrDefault(m => m.Name.ToLower() == name.ToLower());
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
