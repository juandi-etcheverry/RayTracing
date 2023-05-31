using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain;
using IRepository;

namespace RepositoryInDB
{
    public class MaterialRepositoryInDB : IRepositoryMaterial
    {
        public Material Add(Material material)
        {
            using (var context = new BusinessContext())
            {
                context.Materials.Add(material);
                context.SaveChanges();
            }
            return material;
        }

        public List<Material> FindMany(string name)
        {
            using (var context = new BusinessContext())
            {
                return context.Materials.Where(m => m.MaterialName.ToLower().Equals(name.ToLower())).ToList();
            }
        }

        public IList<Material> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Materials.ToList();
            }
        }

        public Material Remove(Material material)
        {
            using (var context = new BusinessContext())
            {
                context.Materials.Remove(material);
                context.SaveChanges();
            }
            return material;
        }
    }
}
