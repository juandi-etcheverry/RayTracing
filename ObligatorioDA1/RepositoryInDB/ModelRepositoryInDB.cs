using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                context.Models.Add(model);
                context.SaveChanges();
            }
            return model;
        }

        public List<Model> FindMany(string name)
        {
            using (var context = new BusinessContext())
            {
                return context.Models.Where(m => m.ModelName.ToLower().Equals(name.ToLower())).ToList();
            }
        }

        public IList<Model> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Models.ToList();
            }
        }

        public Model Remove(Model model)
        {
            using (var context = new BusinessContext())
            {
                context.Models.Remove(model);
                context.SaveChanges();
            }
            return model;
        }
    }
}
