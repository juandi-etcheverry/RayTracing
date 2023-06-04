using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;
using IRepository;

namespace RepositoryInDB
{
    public class ModelRepositoryInDB : IRepositoryModel
    {
        public Model Add(Model model)
        {
            using (var context = new BusinessContext())
            {
                Client loggedClient = context.Clients.FirstOrDefault(c => c.Name == model.Client.Name);
                model.Client = loggedClient;

                Shape shape = context.Shapes.FirstOrDefault(s => s.Id == model.Shape.Id);
                model.Shape = shape;

                Material material = context.Materials.FirstOrDefault(m => m.Id == model.Material.Id);
                model.Material = material;

                context.Models.Add(model);
                context.SaveChanges();
            }
            return model;
        }

        public List<Model> FindMany(string name)
        {
            using (var context = new BusinessContext())
            {
                return context.Models.Include(m => m.Client).Where(m => m.ModelName.ToLower().Equals(name.ToLower())).ToList();
            }
        }

        public IList<Model> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Models
                            .Include(m => m.Client)
                            .Include(m => m.Shape)
                            .Include(m => m.Material)
                            .ToList();
            }
        }

        public Model Remove(Model model)
        {
            using (var context = new BusinessContext())
            {
                Model modelToDelete = context.Models.FirstOrDefault(m => m.Id == model.Id);
                context.Models.Remove(modelToDelete);
                context.SaveChanges();
                return modelToDelete;
            }
        }

        public Model Update(Model model)
        {
            using (var context = new BusinessContext())
            {
                Model modelToUpdate = context.Models.FirstOrDefault(m => m.Id == model.Id);
                modelToUpdate.ModelName = model.ModelName;
                context.SaveChanges();
                return modelToUpdate;
            }
        }
    }
}
