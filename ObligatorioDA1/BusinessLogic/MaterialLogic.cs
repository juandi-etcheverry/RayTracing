using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public Material Remove(Material material)
        {
            ValidateMaterialExists(material);
            _repository.Remove(material);
            return material;
        }

        public Material Rename(Material material, string newName)
        {
            ValidateRenaming(material, newName);
            material.Name = newName;
            return material;
        }


        public Material Get(string name)
        {
            Material existanceValidationMaterial = new Material() { Name = name };
            ValidateMaterialExists(existanceValidationMaterial);
            return _repository.Get(name);
        }
        private void ValidateRenaming(Material material, string newName)
        {
            ValidateMaterialExists(material);
            Material nameUniquenessValidationMaterial = new Material() { Name = newName };
            ValidateMaterialNameUniqueness(nameUniquenessValidationMaterial);
        }

        private void ValidateMaterialNameUniqueness(Material material)
        {
            if (IsMaterialNameInUse(material)) ThrowNameInUse(material.Name);
        }

        private void ValidateMaterialExists(Material material)
        {
            if (!IsMaterialNameInUse(material)) ThrowNotFound(material.Name);
        }

        private void ThrowNameInUse(string name)
        {
            throw new NameException($"Material name {name} is already in use");
        }

        private void ThrowNotFound(string name)
        {
            throw new NotFoundException($"No material with the name {name} was found");
        }

        private bool IsMaterialNameInUse(Material material)
        {
            return _repository.Get(material.Name) != null;
        }
    }
}
