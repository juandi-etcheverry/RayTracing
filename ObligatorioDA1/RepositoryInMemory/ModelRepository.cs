using System.Collections.Generic;
using System.Linq;
using Domain;
using IRepository;

namespace RepositoryInMemory
{
    public class ModelRepository : IRepositoryModel
    {
        private static readonly IList<Model> _models = new List<Model>();

        public Model Add(Model model)
        {
            _models.Add(model);
            return model;
        }

        public IList<Model> GetAll()
        {
            return _models;
        }

        public Model Remove(Model model)
        {
            _models.Remove(model);
            return model;
        }

        public List<Model> FindMany(string name)
        {
            return _models.Where(m => m.ModelName.ToLower().Equals(name.ToLower())).ToList();
        }

        public Model Update(Model x, string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}