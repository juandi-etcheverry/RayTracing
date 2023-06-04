using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.Entity;
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
                Client loggedClient = context.Clients.FirstOrDefault(c => c.Name == material.Client.Name);
                material.Client = loggedClient;

                context.Materials.Add(material);
                context.SaveChanges();
            }
            return material;
        }

        public List<Material> FindMany(string name)
        {
            using (var context = new BusinessContext())
            {
                return context.Materials.Include(m => m.Client).Where(m => m.MaterialName.ToLower().Equals(name.ToLower())).ToList();
            }
        }

        public IList<Material> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Materials.Include(m => m.Client).ToList();
            }
        }

        public Material Remove(Material material)
        {
            using (var context = new BusinessContext())
            {
                Material materialToRemove = context.Materials.FirstOrDefault(m => m.Id == material.Id);
                context.Materials.Remove(materialToRemove);
                context.SaveChanges();
                return materialToRemove;
            }
        }

        public Material Update(Material material, string newName)
        {
            using (var context = new BusinessContext())
            {
                Material materialToUpdate = context.Materials.FirstOrDefault(m => m.Id == material.Id);
                materialToUpdate.MaterialName = newName;
                context.SaveChanges();
                return materialToUpdate;
            }
        }
    }
}
