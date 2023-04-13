using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicExceptions;
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
            ValidateMaterialNameUniqueness(newMaterial);
            _repository.Add(newMaterial);
            return newMaterial;
        }

        public Material Get(string name)
        {
            return _repository.Get(name);
        }

        private void ValidateMaterialNameUniqueness(Material material)
        {
            if (IsMaterialNameInUse(material))
            {
                throw new NameException($"Material name {material.Name} is already in use");
            }
        }

        private bool IsMaterialNameInUse(Material material)
        {
            return Get(material.Name) != null;
        }
    }
}
