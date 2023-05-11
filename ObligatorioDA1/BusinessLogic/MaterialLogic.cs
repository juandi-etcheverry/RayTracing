using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions;
using Domain;
using IRepository;
using RepositoryInMemory;

namespace BusinessLogic
{
    public class MaterialLogic
    {
        private readonly IRepositoryMaterial _repository = new MaterialRepository();

        public IList<Material> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<Material> GetClientMaterials()
        {
            EnsureClientIsLoggedIn();
            return _repository.GetAll().Where(material => material.OwnerName == Session.LoggedClient.Name).ToList();
        }

        public Material Add(Material newMaterial)
        {
            AssignMaterialToClient(newMaterial);
            ValidateMaterialNameUniqueness(newMaterial);
            _repository.Add(newMaterial);
            return newMaterial;
        }

        private void AssignMaterialToClient(Material material)
        {
            EnsureClientIsLoggedIn();
            material.OwnerName = Session.LoggedClient.Name;
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) ThrowClientNotLoggedIn();
        }

        public Material Remove(Material material)
        {
            ValidateMaterialExists(material);
            ValidateMaterialReferencedByModel(material);
            _repository.Remove(material);
            return material;
        }

        private void ValidateMaterialReferencedByModel(Material material)
        {
            var modelLogic = new ModelLogic();
            var isMaterialInUse = modelLogic.GetClientModels().Any(model => model.Material.Name == material.Name);
            if (isMaterialInUse) ThrowMaterialReferencedByModel();
        }

        public Material Rename(Material material, string newName)
        {
            ValidateRenaming(material, newName);
            material.Name = newName;
            return material;
        }


        public Material Get(string name)
        {
            var existanceValidationMaterial = new Material { Name = name };
            AssignMaterialToClient(existanceValidationMaterial);
            ValidateMaterialExists(existanceValidationMaterial);
            return GetMaterialForOwner(existanceValidationMaterial);
        }

        private void ValidateRenaming(Material material, string newName)
        {
            ValidateMaterialExists(material);
            var nameUniquenessValidationMaterial = new Material { Name = newName };
            AssignMaterialToClient(nameUniquenessValidationMaterial);
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
        public void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client needs to be logged in to create new Material");
        }

        public void ThrowMaterialReferencedByModel()
        {
            throw new AssociationException("Material is already being used by a Model.");
        }

        private bool IsMaterialNameInUse(Material material)
        {
            var existingMaterials = _repository.FindMany(material.Name);
            return existingMaterials.Exists(existingMaterial => existingMaterial.OwnerName == material.OwnerName);
        }

        private Material GetMaterialForOwner(Material checkMaterial)
        {
            return GetClientMaterials()
                .FirstOrDefault(material => material.Name.ToLower() == checkMaterial.Name.ToLower());
        }
    }
}