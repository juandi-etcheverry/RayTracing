using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using IRepository;
using RepositoryInMemory;

namespace BusinessLogic
{
    public class MaterialLogic
    {
        private IRepositoryMaterial _repository = new MaterialRepository();

        public IList<Material> GetAll()
        {
            return _repository.GetAll();
        }

        public Material Add(Material newMaterial)
        {
            _repository.Add(newMaterial);
            return newMaterial;
        }
    }
}
